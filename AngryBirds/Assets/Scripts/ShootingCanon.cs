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
    private RotateCanonToPoint rotateCanonToPoint;
    [SerializeField] private float force = 5f;
    private int balaADisparar = 0;
    private bool puedoVolverADisparar = true;
    private Bullet balaEnElAire;


    private void Awake()
    {
        SharedInstance= this;
        GameInputManager.SharedInsatance.OnInteractPush += GameInputManager_OnInteractPush;
        rotateCanonToPoint = GetComponent<RotateCanonToPoint>();
    }

    private void GameInputManager_OnInteractPush(object sender, System.EventArgs e)
    {
        if (puedoVolverADisparar)
        {
            balaEnElAire = null;
            InstanciaBalayDispara();
        }
        else{
            puedoVolverADisparar=true;
            balaEnElAire.RealizaAccionEspecial();
            balaEnElAire = null;
        }
    }

    private void InstanciaBalayDispara()
    {
        BulletSO bulletSO = listBulletsSO.bullets[balaADisparar];
        puedoVolverADisparar = !bulletSO.accionDespeusDeSerDisparado;
        Transform bullet = Instantiate(bulletSO.Prefab, bocaDeCanon.position, Quaternion.identity, bulletPool);
        balaEnElAire = bullet.GetComponent<Bullet>();
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(rotateCanonToPoint.GetOrientation().normalized * force, ForceMode.Impulse);
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
