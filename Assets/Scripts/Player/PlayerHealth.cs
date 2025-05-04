using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
    public int currentHealth;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
