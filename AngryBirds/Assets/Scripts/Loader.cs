using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    
    public enum Scene
    {
        MainMenu,
        SampleScene,
        Loading
    }

    public static Scene targetScene;



    private const string MAX_SCORE = "maxScore";

    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void CallBack()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static string GetMaxScoreName(int level)
    {
        string name = MAX_SCORE + level.ToString();
        return name;
    }
}
