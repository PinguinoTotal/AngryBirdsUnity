using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.SharedInstance.ReanudaElJuegoEnPausa();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            GameManager.SharedInstance.GoToMainMenu();
        });
    }
}
