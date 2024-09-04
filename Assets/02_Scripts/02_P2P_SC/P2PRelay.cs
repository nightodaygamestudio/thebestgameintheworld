using QFSW.QC;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using System.Security.Cryptography;
using UnityEngine.UI;



public class P2PRelay : MonoBehaviour 
{
    /*
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button joinBtn;

    private void Awake()
    {
        hostBtn.onClick.AddListener(() => {
            CreateRelay();  
        });
        joinBtn.onClick.AddListener(() => {
            JoinRelay(string joinCode);
        });
    }
    */

    private async void Start()  {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () => {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

    }

    [Command]
    public async void CreateRelay() {
        try { 
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(1);

            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            Debug.Log(joinCode);

            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();

        } catch (RelayServiceException e) {
            Debug.Log(e); 
        }
    }

    [Command]
    public async void JoinRelay(string joinCode) {
        try
        {
            Debug.Log("Joining Relay with " + joinCode);
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();
        }catch (RelayServiceException e) {
            Debug.Log(e);
        }
    }
}
