using UnityEngine;

public class BoolControler : MonoBehaviour

{
    public static BoolControler Instance { get; private set; }

    //-----------//

    public bool HasBeenHit;

    //-----------//
    private void Awake()
    {
        Instance = this;
    }


}
