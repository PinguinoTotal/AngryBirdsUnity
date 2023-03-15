using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ListBulletsSO : ScriptableObject
{
    public List<BulletSO> bullets = new List<BulletSO>();
}
