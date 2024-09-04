using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] float maxHealth;
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
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}