using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;

    public void Start()
    {
        UpdateAllStats();
    }

    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatsManager.Instance.damage;
    }

    public void UpdateHealth()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Health: " + StatsManager.Instance.maxHealth;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateHealth();
    }
}
