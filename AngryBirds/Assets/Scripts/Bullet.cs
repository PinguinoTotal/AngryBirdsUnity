using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO bulletsSO;
    [SerializeField] private float explosionRadius = 100;
    [SerializeField] private float explosionForce = 2000;

    public BulletSO GetBulletSO()
    {
        return bulletsSO;
    }

    public void RealizaAccionEspecial()
    {
        BulletSO.TipoDeBala miBala = bulletsSO.tipoDeBala;
        switch (miBala)
        {
            case BulletSO.TipoDeBala.Conejo:
                Debug.LogError("la funcion realiza accion se esta llamando y la bala es tipo red");
                break;

            case BulletSO.TipoDeBala.Rana:
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                rigidbody.velocity = rigidbody.velocity * 1.5f;
                Debug.Log("yellow esta acelerando");
                break;

            case BulletSO.TipoDeBala.Tlacuache:
                explosionRadius = 100;
                explosionForce = 2000;
                var surroundingObjects = Physics.OverlapSphere(transform.position, explosionRadius);
                Debug.Log("bomb esta explotando");

                foreach (var ob in surroundingObjects)
                {
                    Rigidbody rb = ob.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    }
                }

            break;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShootingCanon.SharedInstance.ListoParaVolverADisparar(this);
    }
}
