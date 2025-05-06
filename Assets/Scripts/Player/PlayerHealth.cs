using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;

    private void Start()
    {
        healthSlider.maxValue = StatsManager.Instance.maxHealth;
        healthSlider.value = StatsManager.Instance.currentHealth;
    }
    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;
        healthSlider.value = StatsManager.Instance.currentHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
