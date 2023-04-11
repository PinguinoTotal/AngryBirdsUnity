using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager SharedInstance;

    [SerializeField] private List<GameObject> levels= new List<GameObject>();
    
    public void SetLevel(int level)
    {
        levels[level].SetActive(true);
    }
}
