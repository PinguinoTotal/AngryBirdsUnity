using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public enum estatusDeLaCamara
{
    siguiendoBala,
    viendoAlCanon,
    ViendoLaEstructura

}

public class CamaraManager : MonoBehaviour
{
    public static CamaraManager sharedInstance { get; private set; }

    

    [SerializeField] CinemachineVirtualCamera camaraDeCañon;
    [SerializeField] CinemachineVirtualCamera camaraDeBullet;
    [SerializeField] CinemachineVirtualCamera camaraDeEstructura;

    [SerializeField] private estatusDeLaCamara estatus;
    private void Awake()
    {
        sharedInstance = this;
        MirandoAlCanon();
    }

    public void MirandoLaBala(Transform bullet)
    {
        estatus = estatusDeLaCamara.siguiendoBala;
        PrioridadDeCamaras(10,50,10);
        camaraDeBullet.LookAt = bullet;
        camaraDeBullet.Follow= bullet;
        
    }

    public void DejaDeVerLaBala()
    {
        camaraDeBullet.LookAt = null;
        camaraDeBullet.Follow = null;
    }

    public void MirandoLaEstructura()
    {
        estatus = estatusDeLaCamara.ViendoLaEstructura;
        PrioridadDeCamaras(10, 10, 50);
    }
    public void MirandoAlCanon()
    {
        estatus = estatusDeLaCamara.viendoAlCanon;
        PrioridadDeCamaras(50,10,10);
    }

    /// <summary>
    /// Funcion que nos permite cambiar entre camaras
    /// </summary>
    /// <param name="priCanon">prioriddad de la camara del cañon</param>
    /// <param name="priBullet">prioriddad de la camara de la bala</param>
    /// <param name="priEstructura">prioriddad de la camara de la estructura</param>
    private void PrioridadDeCamaras(int priCanon, int priBullet, int priEstructura)
    {
        camaraDeCañon.Priority = priCanon;
        camaraDeBullet.Priority = priBullet;
        camaraDeEstructura.Priority = priEstructura;
    }

    public estatusDeLaCamara GetEstatusDeLaCamara()
    {
        return estatus;
    }
}
