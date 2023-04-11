using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager SharedInstance;

    [SerializeField] private GameObject PlayPanel;
    [SerializeField] private GameObject LevelPanel;

    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;

    [SerializeField] private Button BackButton;

    private void Awake()
    {
        SharedInstance= this;

        PlayButton.onClick.AddListener(() =>
        {
            LevelPanel.SetActive(true);
            PlayPanel.SetActive(false);
        });

        QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        BackButton.onClick.AddListener(() =>
        {
            LevelPanel.SetActive(false);
            PlayPanel.SetActive(true);
        });
    }
}
