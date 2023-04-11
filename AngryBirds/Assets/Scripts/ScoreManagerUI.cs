using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManagerUI : MonoBehaviour
{
    public static ScoreManagerUI SharedInstance;

    [SerializeField] private TextMeshProUGUI scoreNumText;

    [SerializeField] private TextMeshProUGUI patosEnPantalla;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void MuestraScore(int numeros)
    {
        scoreNumText.text = numeros.ToString();
    }

    public void ActualizaPatosEnPantalla(int numeroDePatos)
    {
        patosEnPantalla.text = numeroDePatos.ToString();
    }
}
