using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaDestruida : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject,30f);
    }
}
