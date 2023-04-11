using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pato : MonoBehaviour
{
    [SerializeField] int puntosQueDara;
    private AudioSource audioDelPato;
    private bool yaDiMiPuntaje;
    private bool patoContado = false;
    private bool yaSone;


    private void Start()
    {
        audioDelPato = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!patoContado)
        {
            patoContado= true;
            GameManager.SharedInstance.CuentaUnPato();
        }
    }

    private void PlayPatoDead()
    {
        if (!yaSone)
        {
            audioDelPato.Play();
            yaSone= true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            PlayPatoDead();
            PatoEliminado();
        }
    }

    public void PatoEliminado()
    {

        Debug.Log("El pato ha sido eliminado");
        PlayPatoDead();

        if (!yaDiMiPuntaje)
        {
            yaDiMiPuntaje= true;

            GameManager.SharedInstance.SumaPuntos(puntosQueDara);
            GameManager.SharedInstance.EliminaPato();

            Destroy(this.gameObject, 10f);
        }
        
    }
}
