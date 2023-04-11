using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButons : MonoBehaviour
{
    [SerializeField] Button myButon;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] int myLevel;

    private void Awake()
    {
        myButon.onClick.AddListener(() => {
            PlayerPrefs.SetInt("LEVEL",myLevel);
            Loader.Load(Loader.Scene.SampleScene);
        });
    }

    private void Start()
    {
        levelText.text = myLevel.ToString();
        string maxScoreScoreOfThisLevelName = Loader.GetMaxScoreName(myLevel);
        int maxScoreScoreOfThisLevel = PlayerPrefs.GetInt(maxScoreScoreOfThisLevelName);
        bestScoreText.text = maxScoreScoreOfThisLevel.ToString(); 
    }
}
