using UnityEngine;

public class PlayerHealth : MonoBehaviour, i_Update
{
    public float maxHealth;
    public float currentHealth;
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    public void CostumUpdate()
    {
        if (!BoolControler.Instance.isDead)
        {
            if (HitControler.Instance.Head_Neck_Hit == true) { Die_BodyPart(); }
            if (HitControler.Instance.Torso_Waist_Hit == true) { Die_BodyPart(); }
            if (HitControler.Instance.L_Thigh_Hit == true && HitControler.Instance.R_Thigh_Hit == true) { Die_BodyPart(); }
        }
    }
    public void Die_BodyPart() { BoolControler.Instance.isDead = true; Debug.Log("Die"); StartCoroutine(HitControler.Instance.SlowMow()); }
    public void Die_HealthLoss() { if (currentHealth >= 0f) { BoolControler.Instance.isDead = true; } }
}
