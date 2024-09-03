using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyAssets : MonoBehaviour {



    public static LobbyAssets Instance { get; private set; }


    [SerializeField] private Sprite greenSprite;
    [SerializeField] private Sprite orangeSprite;
    [SerializeField] private Sprite purpleSprite;
    [SerializeField] private Sprite redSprite;
    [SerializeField] private Sprite violetSprite;
    [SerializeField] private Sprite yellowSprite;
    [SerializeField] private Sprite blueSprite;


    private void Awake() {
        Instance = this;
    }

    public Sprite GetSprite(LobbyManager.PlayerCharacter playerCharacter) {
        switch (playerCharacter) {
            default:
            case LobbyManager.PlayerCharacter.Green:   return greenSprite;
            case LobbyManager.PlayerCharacter.Orange: return orangeSprite;
            case LobbyManager.PlayerCharacter.Purple: return purpleSprite;
            case LobbyManager.PlayerCharacter.Red: return redSprite;
            case LobbyManager.PlayerCharacter.Violet: return violetSprite;
            case LobbyManager.PlayerCharacter.Yellow: return yellowSprite;
            case LobbyManager.PlayerCharacter.Blue: return blueSprite;

        }
    }

}