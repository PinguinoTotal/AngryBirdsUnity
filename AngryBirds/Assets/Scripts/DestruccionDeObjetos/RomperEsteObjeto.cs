using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperEsteObjeto : MonoBehaviour
{
    [SerializeField] private ElementoEstructuralRompibleSO elementoEstructuralRompibleSO;
    [SerializeField] private Transform contenedorEstructural;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= elementoEstructuralRompibleSO.resitencia)
        {

            //Debug.Log("objeto" + gameObject + "roto");
            if (contenedorEstructural !=null)
            {
                Instantiate(elementoEstructuralRompibleSO.ObjetoRoto, transform.position, transform.rotation, contenedorEstructural);
            }
            else
            {
                Instantiate(elementoEstructuralRompibleSO.ObjetoRoto, transform.position, transform.rotation);
            }
            
            Destroy(this.gameObject);
            
            
        }
    } 
}

