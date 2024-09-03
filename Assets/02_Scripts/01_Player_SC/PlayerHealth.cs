using UnityEngine;

public class PlayerHealth : MonoBehaviour, i_Update
{
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    public void CostumUpdate()
    {
        if (!BoolControler.Instance.isDead)
        {
            if (HitControler.Instance.Head_Neck_Hit == true) { DIE(); }
            if (HitControler.Instance.Torso_Waist_Hit == true) { DIE(); }
            if (HitControler.Instance.L_Thigh_Hit == true && HitControler.Instance.R_Thigh_Hit == true) { DIE(); }
        }
    }
    public void DIE() { BoolControler.Instance.isDead = true; Debug.Log("Die"); StartCoroutine(HitControler.Instance.SlowMow()); }
}
