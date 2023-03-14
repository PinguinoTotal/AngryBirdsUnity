using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO bulletsSO;

    BulletSO GetBulletSO()
    {
        return bulletsSO;
    }
}
