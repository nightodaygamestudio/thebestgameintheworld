using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, i_Update
{
    [SerializeField] Slider healthSlider;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }


    private void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.UnregisterUpdate(this);
    }

    public void CostumUpdate()
    {
        if (!BoolControler.Instance.isDead)
        {
            if (HitController.Instance.Head_Neck_Hit || HitController.Instance.Torso_Waist_Hit || (HitController.Instance.L_Thigh_Hit && HitController.Instance.R_Thigh_Hit))
            {
                Die();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!BoolControler.Instance.isDead)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        BoolControler.Instance.isDead = true;
        StartCoroutine(HitController.Instance.SlowMow());
        healthSlider.value = 0f;
    }
}