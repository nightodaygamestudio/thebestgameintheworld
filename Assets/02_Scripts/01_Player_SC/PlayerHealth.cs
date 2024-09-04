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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
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
            if (HitControler.Instance.Head_Neck_Hit || HitControler.Instance.Torso_Waist_Hit ||
                (HitControler.Instance.L_Thigh_Hit && HitControler.Instance.R_Thigh_Hit))
            {
                Die_BodyPart();
            }
        }
    }

    public void Die_BodyPart()
    {
        BoolControler.Instance.isDead = true;
        StartCoroutine(HitControler.Instance.SlowMow());
    }

    private void Die()
    {
        BoolControler.Instance.isDead = true;
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}