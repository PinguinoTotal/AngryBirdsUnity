using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageInButon : MonoBehaviour
{
    [SerializeField] private Sprite imagenDeConejo;
    [SerializeField] private Sprite imagenDeRana;
    [SerializeField] private Sprite imagenDeTlacuache;

    [SerializeField] private Button imagenButton;
    [SerializeField] private Image imagenDelBoton;

    [SerializeField] private int conteoImagen = 0;

    [SerializeField] private TextMeshProUGUI costeText;

    [SerializeField] private Button pauseButton;


    private void Awake()
    {
        pauseButton.onClick.AddListener(() =>
        {
            Debug.Log("pausa puchurrado");
            GameManager.SharedInstance.JuegoEnPausa();
        });



        costeText.text = "10";


        imagenButton.onClick.AddListener(() =>
        {
            conteoImagen++;

            if (conteoImagen>=3)
            {
                conteoImagen=0;
            }

            ShootingCanon.SharedInstance.SetBalaADisparar(conteoImagen);
            if (conteoImagen==0)
            {
                imagenDelBoton.sprite = imagenDeConejo;
                costeText.text = "10";
            }
            if (conteoImagen == 1)
            {
                imagenDelBoton.sprite = imagenDeRana;
                costeText.text = "20";
            }
            if (conteoImagen == 2)
            {
                imagenDelBoton.sprite = imagenDeTlacuache;
                costeText.text = "30";
            }
        });
    }
}
