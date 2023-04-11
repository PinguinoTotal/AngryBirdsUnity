using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagerUI : MonoBehaviour
{
    public static CanvasManagerUI SharedInstance;

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void HideGameOverMenu()
    {
        gameOverMenu.SetActive(false);
    }
    
    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
}
