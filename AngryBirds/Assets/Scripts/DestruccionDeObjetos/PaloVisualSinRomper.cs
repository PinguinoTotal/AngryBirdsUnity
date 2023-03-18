using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PaloVisualSinRomper : MonoBehaviour
{
    [SerializeField] private Transform PaloRoto;
    [SerializeField] private Transform padreTransform;
    private float fuerzaDeImpacto = 80.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if(collision.relativeVelocity.magnitude >= fuerzaDeImpacto)
        {
            Debug.Log("barra de madera rompiendose");
            Instantiate(PaloRoto,transform.position,transform.rotation,padreTransform);
            Destroy(this.gameObject);
        }
    }
}
