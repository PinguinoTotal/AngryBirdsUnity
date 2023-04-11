using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public enum EstadoDelJuego
    {
        enJuego,
        pausa,
        gameOver,
        tutorial,
    }

    [SerializeField] private bool modoDebug;
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    [SerializeField] private EstadoDelJuego estadoDelJuego;

    private int score = 0;

    [SerializeField] private int patosEnJuego;
    [SerializeField] private GameObject TutorialPanel;


    private int level;
    private bool tutorial;

    private void Awake()
    {
        SharedInstance= this;
        GameInputManager.SharedInsatance.OnInteractPush += GameInputManager_OnInteractPush;
        

        estadoDelJuego= EstadoDelJuego.enJuego;
    }

    private void GameInputManager_OnInteractPush(object sender, EventArgs e)
    {
        
        if (tutorial)
        {
            tutorial= false;
            TutorialPanel.SetActive(false);
            estadoDelJuego = EstadoDelJuego.enJuego;
        }
    }

    private void Start()
    {
        if (!modoDebug)
        {
            level = PlayerPrefs.GetInt("LEVEL");

            ScoreManagerUI.SharedInstance.ActualizaPatosEnPantalla(patosEnJuego);

            if (level == 0)
            {
                tutorial = true;
                TutorialPanel.SetActive(true);
                estadoDelJuego = EstadoDelJuego.tutorial;
            }

            levels[level].SetActive(true);
        }

        

    }

    public void SumaPuntos(int numero)
    {
        score = score + numero;
        ScoreManagerUI.SharedInstance.MuestraScore(score);
        
    }

    public void CuentaUnPato()
    {
        patosEnJuego++;
        ScoreManagerUI.SharedInstance.ActualizaPatosEnPantalla(patosEnJuego);

    }
    public void EliminaPato()
    {
        patosEnJuego--;
        ScoreManagerUI.SharedInstance.ActualizaPatosEnPantalla(patosEnJuego);
        if (patosEnJuego == 0)
        {
            Debug.Log("has ganado");
            GameOver();
        }
    }

    public void JuegoEnPausa()
    {
        estadoDelJuego = EstadoDelJuego.pausa;
        CanvasManagerUI.SharedInstance.ShowPauseMenu();
    }

    public void ReanudaElJuegoEnPausa()
    {
        estadoDelJuego = EstadoDelJuego.enJuego;
        CanvasManagerUI.SharedInstance.HidePauseMenu();
    }

    private void GameOver()
    {
        estadoDelJuego = EstadoDelJuego.gameOver;
        CanvasManagerUI.SharedInstance.ShowGameOverMenu();
        GameOverMenuUI.SharedInsance.GameOverInfo(score);
    }

    public void GoToMainMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

    public EstadoDelJuego GetEstadoDelJuego()
    {
        return estadoDelJuego;
    }
}
