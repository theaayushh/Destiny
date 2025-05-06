using JetBrains.Annotations;
using UnityEngine;

public class PauseUi : MonoBehaviour
{
    public CanvasGroup pauseMenu;
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
                isOpen = false;
            }
            else
            {
                //statsUI.UpdateAllStats();
                Time.timeScale = 0;
                pauseMenu.alpha = 1;
                isOpen = true;
            }
        }
    }
}
