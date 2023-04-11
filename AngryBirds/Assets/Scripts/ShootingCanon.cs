using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingCanon : MonoBehaviour
{
    public static ShootingCanon SharedInstance;

    [SerializeField] private ListBulletsSO listBulletsSO;
    [SerializeField] private Transform bocaDeCanon;
    [SerializeField] private Transform bulletPool;
    [SerializeField] private ParticleSystem explosion;
    private RotateCanonToPoint rotateCanonToPoint;
    [SerializeField] private float force = 5f;
    [SerializeField] private int balaADisparar = 0;
    [SerializeField] private bool puedoVolverADisparar = true;
    [SerializeField] private Bullet balaEnElAire;
    [SerializeField] private estatusDeLaCamara estatusDeLaCamara;
    [SerializeField] private AudioSource audioDelCanon;


    private void Awake()
    {
        SharedInstance = this;
        rotateCanonToPoint = GetComponent<RotateCanonToPoint>();
        
    }
    private void Start()
    {

        GameInputManager.SharedInsatance.OnInteractPush += GameInputManager_OnInteractPush;
        estatusDeLaCamara = CamaraManager.sharedInstance.GetEstatusDeLaCamara();
        audioDelCanon= GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    private void GameInputManager_OnInteractPush(object sender, System.EventArgs e)
    {
        if (GameManager.SharedInstance.GetEstadoDelJuego() == GameManager.EstadoDelJuego.enJuego)
        {
            estatusDeLaCamara = CamaraManager.sharedInstance.GetEstatusDeLaCamara();

            switch (estatusDeLaCamara)
            {
                case estatusDeLaCamara.ViendoLaEstructura:
                    CamaraManager.sharedInstance.MirandoAlCanon();
                    PointerManager.SharedInstance.MuestraTiro();
                    Debug.Log("viendo al cañon");
                    break;

                case estatusDeLaCamara.viendoAlCanon:
                    Debug.Log("disparando el cañon");
                    audioDelCanon.Play();
                    InstanciaBalayDispara();
                    PointerManager.SharedInstance.DisparaYGuardaValor();
                    break;

                case estatusDeLaCamara.siguiendoBala:
                    Debug.Log("mirando la estructura");
                    if (!puedoVolverADisparar)
                    {
                        puedoVolverADisparar = true;
                        balaEnElAire.RealizaAccionEspecial();
                    }
                    CamaraManager.sharedInstance.DejaDeVerLaBala();
                    balaEnElAire = null;
                    CamaraManager.sharedInstance.MirandoLaEstructura();
                    break;
                
            }
        }
    }

    private void InstanciaBalayDispara()
    {
        BulletSO bulletSO = listBulletsSO.bullets[balaADisparar];
        puedoVolverADisparar = !bulletSO.accionDespeusDeSerDisparado;
        Transform bullet = Instantiate(bulletSO.Prefab, bocaDeCanon.position, Quaternion.identity, bulletPool);



        GameManager.SharedInstance.SumaPuntos(-(bulletSO.costeDeBala));
        
        CamaraManager.sharedInstance.MirandoLaBala(bullet);

        balaEnElAire = bullet.GetComponent<Bullet>();
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(rotateCanonToPoint.GetOrientation().normalized * force, ForceMode.Impulse);
        explosion.Play();
    }

    public void SetBalaADisparar(int index)
    {
        balaADisparar= index;
    }

    public void ListoParaVolverADisparar(Bullet bulletMesage)
    {
        if (bulletMesage == balaEnElAire)
        {
            puedoVolverADisparar = true;
        }
        
    }

    

    
}
