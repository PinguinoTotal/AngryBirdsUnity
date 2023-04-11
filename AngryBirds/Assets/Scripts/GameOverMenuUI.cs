using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuUI : MonoBehaviour
{
    public static GameOverMenuUI SharedInsance;

    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TextMeshProUGUI yourScore;

    [SerializeField] private GameObject youLose;
    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject newRecord;

    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button reestart;

    private const string LEVEL = "level";
    private const string MAX_SCORE = "maxScore";
    private int level = 0;

    private void Awake()
    {
        SharedInsance= this;

        mainMenuButton.onClick.AddListener(() =>
        {
            GameManager.SharedInstance.GoToMainMenu();
        });

        reestart.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.SampleScene);
        });

    }

    public void GameOverInfo(int yourRecord)
    {

        level = PlayerPrefs.GetInt("LEVEL"); ;

        string maxScoreName = Loader.GetMaxScoreName(level);
        int maxScore = PlayerPrefs.GetInt(maxScoreName);

        InicializaMenuGameOver();


        if (yourRecord<=0)
        {
            youLose.SetActive(true);
        }
        else
        {
            youWin.SetActive(true);
        }

        if (yourRecord>maxScore)
        {
            newRecord.SetActive(true);
            PlayerPrefs.SetInt(maxScoreName,yourRecord);
        }

        bestScore.text = PlayerPrefs.GetInt(maxScoreName).ToString();
        yourScore.text = yourRecord.ToString();
    }

    private void InicializaMenuGameOver()
    {
        youLose.SetActive(false);
        youWin.SetActive(false);
        newRecord.SetActive(false);
    }
}
