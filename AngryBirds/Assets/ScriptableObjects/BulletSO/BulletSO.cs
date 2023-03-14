using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]

public class BulletSO : ScriptableObject
{
    public enum TipoDeBala
    {
        Red,
        Yellow,
        Bomb
    }
    public TipoDeBala tipoDeBala;
    public Transform Prefab;
    public bool accionDespeusDeSerDisparado;
}
