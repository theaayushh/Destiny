using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PauseUi : MonoBehaviour
{
    public CanvasGroup pauseMenu;
    public CanvasGroup settings;
    public CanvasGroup inventory;
    public CanvasGroup profile;
    public CanvasGroup stats;
    public CanvasGroup quests;

    private bool isOpen = false;
    //public StatsUI statsUI;
    public void Update()
    {
        
        if (Input.GetButtonDown("Pause"))
        {
            if(isOpen)
            {
                //statsUI.UpdateAllStats();
                Time.timeScale = 1;
                pauseMenu.alpha = 0;
                settings.alpha = 0;
                inventory.alpha = 0;
                profile.alpha = 0;
                stats.alpha = 0;
                quests.alpha = 0;
                settings.blocksRaycasts = false;
                inventory.blocksRaycasts = false;
                profile.blocksRaycasts = false;
                stats.blocksRaycasts = false;
                quests.blocksRaycasts = false;
                isOpen = false;
            }
            else
            {
                //statsUI.UpdateAllStats();
                
                Time.timeScale = 0;
                pauseMenu.alpha = 1;
                profile.blocksRaycasts = true;
                profile.alpha = 1;
                isOpen = true;
            }
        }
    }

    public void SettingsButton()
    {
        if (isOpen)
        {
            settings.blocksRaycasts = true;
            settings.alpha = 1;
            inventory.blocksRaycasts = false;
            inventory.alpha = 0;
            profile.blocksRaycasts = false;
            profile.alpha = 0;
            stats.blocksRaycasts = false;
            stats.alpha = 0;
            quests.blocksRaycasts = false;
            quests.alpha = 0;
        }
    }

    public void InventoryButton()
    {
        if (isOpen)
        {
            settings.blocksRaycasts = false;
            settings.alpha = 0;
            inventory.blocksRaycasts = true;
            inventory.alpha = 1;
            profile.blocksRaycasts = false;
            profile.alpha = 0;
            stats.blocksRaycasts = false;
            stats.alpha = 0;
            quests.blocksRaycasts = false;
            quests.alpha = 0;
        }
    }

    public void ProfileButton()
    {
        if (isOpen)
        {
            settings.blocksRaycasts = false;
            settings.alpha = 0;
            inventory.blocksRaycasts = false;
            inventory.alpha = 0;
            profile.blocksRaycasts = true;
            profile.alpha = 1;
            stats.blocksRaycasts = false;
            stats.alpha = 0;
            quests.blocksRaycasts = false;
            quests.alpha = 0;
        }
    }
    public void StatsButton()
    {
        if (isOpen)
        {
            settings.blocksRaycasts = false;
            settings.alpha = 0;

            inventory.blocksRaycasts = false;
            inventory.alpha = 0;

            profile.blocksRaycasts = false;
            profile.alpha = 0;

            stats.blocksRaycasts = true;
            stats.alpha = 1;

            quests.interactable = false;
            quests.alpha = 0;
        }
    }
    public void QuestsButton()
    {
        if (isOpen)
        {
            settings.blocksRaycasts = false;
            settings.alpha = 0;

            inventory.blocksRaycasts = false;
            inventory.alpha = 0;

            profile.blocksRaycasts = false;
            profile.alpha = 0;

            stats.blocksRaycasts = false;
            stats.alpha = 0;

            quests.interactable = true;
            quests.alpha = 1;
        }
    }
}
