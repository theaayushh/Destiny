using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    private int points;
    public TMP_Text pointsText;

    public void Start()
    {
        UpdateAllStats();
        UpdatePoints();
    }

    public void UpdatePoints()
    { 
        pointsText.text = "Points: " + points;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePoints();
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

    public void IncreaseDamage()
    {
        if (points > 0)
        {
            points--;
            UpdatePoints();
            StatsManager.Instance.damage += 1;
            UpdateDamage();
        }
    }

    public void IncreaseHealth()
    {
        if (points > 0)
        {
            points--;
            UpdatePoints();
            StatsManager.Instance.maxHealth += 1;
            UpdateHealth();
        }
    }
}
