using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : MonoBehaviour
{
    public static PointerManager SharedInstance { get; private set; }
    [SerializeField] Transform redTraget;
    [SerializeField] Transform blackTraget;
    private Vector3 ultimoTiro;

    private void Awake()
    {
        SharedInstance= this;
        redTraget.gameObject.SetActive(true);
        blackTraget.gameObject.SetActive(false);
    }

    public void DisparaYGuardaValor()
    {
        ultimoTiro = redTraget.position;
        redTraget.gameObject.SetActive(false);
        blackTraget.gameObject.SetActive(false);
    }

    public void MuestraTiro()
    {
        if (ultimoTiro != Vector3.zero)
        {
            blackTraget.gameObject.SetActive(true);
            blackTraget.position = ultimoTiro;
            redTraget.gameObject.SetActive(true);

        }
    }


}
