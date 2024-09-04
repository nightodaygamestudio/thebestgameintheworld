using System.Collections;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public static HitController Instance { get; private set; }

    //-----------//
    public float SloMoFactor;
    public float SloMoTime;
    public bool Head_Neck_Hit;
    public bool Torso_Waist_Hit;
    public bool L_Thigh_Hit;
    public bool R_Thigh_Hit;
    public bool HasBeenHit;
    public GameObject hitEffectBlood;

    //-----------//

    public IEnumerator SlowMow()
    {
        Time.timeScale = SloMoFactor;
        yield return new WaitForSeconds(SloMoTime);
        Time.timeScale = 1f;
    }
    //-----------//
    private void Awake()
    { 
        Instance = this;
    }
}