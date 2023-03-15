using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingCanon : MonoBehaviour
{
    [SerializeField] private ListBulletsSO listBulletsSO;
    [SerializeField] private Transform bocaDeCanon;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform bulletPool;
    [SerializeField] private RotateCanonToPoint rotateCanonToPoint;
    [SerializeField] private float force = 5f;
    
   
    private void Awake()
    {
        gameInput.OnInteractPush += GameInput_OnInteractPush;
    }

    private void GameInput_OnInteractPush(object sender, System.EventArgs e)
    {
        BulletSO bulletSO = listBulletsSO.bullets[0];
        Transform bullet = Instantiate(bulletSO.Prefab, bocaDeCanon.position, Quaternion.identity, bulletPool);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(rotateCanonToPoint.GetOrientation().normalized * force, ForceMode.Impulse);
        
    }

    
}
