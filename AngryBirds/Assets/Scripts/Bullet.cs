using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO bulletsSO;
    [SerializeField] private float explosionRadius = 100;
    [SerializeField] private float explosionForce = 2000;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private ListaDeSonidosSO listaSounds;
    
    private Rigidbody rb;
    private AudioSource mySounds;
    private bool yaImpacte;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mySounds = GetComponent<AudioSource>();
        int screamNum = Random.Range(0,listaSounds.screams.Count);
        AudioClip scream = listaSounds.screams[screamNum];
        ChangeAudioAndPlay(scream);
    }

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
                ChangeAudioAndPlay(listaSounds.explosion);
                Debug.Log("bomb esta explotando");

                foreach (var ob in surroundingObjects)
                {
                    Rigidbody rb = ob.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    }
                }
                rb.velocity = Vector3.zero;
                explosion.Play();
                Destroy(this.gameObject,.3f);

            break;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!yaImpacte && CamaraManager.sharedInstance.GetEstatusDeLaCamara()!=estatusDeLaCamara.viendoAlCanon)
        {
            ChangeAudioAndPlay(listaSounds.bonk);
            CamaraManager.sharedInstance.DejaDeVerLaBala();
            CamaraManager.sharedInstance.MirandoLaEstructura();
            yaImpacte = true;
            Destroy(this.gameObject,5f);
        }
        
    }

    private void ChangeAudioAndPlay(AudioClip clip)
    {
        mySounds.clip = clip;
        mySounds.Play();
    }
}
