using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{
    public int level = 1;
    public int currentExp;
    public int expToNextLevel = 10;
    public float expMultiplier = 1.5f;
    public Slider expSlider;
    public TMP_Text levelText;

    public void Start()
    {
        UpdateUI();
    }

    public void GainExp(int amount)
    {
        currentExp += amount;
        if(currentExp >= expToNextLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void OnEnable()
    {
        EnemyHealth.OnMonsterDefeated += GainExp; // Subscribe to the event
    }

    private void OnDisable()
    {
        EnemyHealth.OnMonsterDefeated -= GainExp; // Unsubscribe from the event
    }


    public void LevelUp()
    {
        level++;
        currentExp -= expToNextLevel;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * expMultiplier); // Increase the required exp for the next level
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToNextLevel;
        expSlider.value = currentExp;
        levelText.text = level.ToString();
    }
}
