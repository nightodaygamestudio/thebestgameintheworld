using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : NetworkBehaviour
{

    [SerializeField] private Button hostBtn;
    [SerializeField] private Button joinBtn;

    private void Awake()
    {
        hostBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });
        joinBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
    }
}