using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO bulletsSO;
    [SerializeField] private GameInput gameInput;
    private bool impacto;
    private bool yaHizoEspecial;

    private void Awake()
    {
        gameInput.OnInteractPush += GameInput_OnInteractPush;
    }

    private void GameInput_OnInteractPush(object sender, System.EventArgs e)
    {
        if (!yaHizoEspecial && bulletsSO.accionDespeusDeSerDisparado && !impacto)
        {
            yaHizoEspecial= true;
            RealizaMovimientoEspecial();
        }
    }

    private void RealizaMovimientoEspecial()
    {
        Debug.Log("Realizando movimiento especial");
    }

    BulletSO GetBulletSO()
    {
        return bulletsSO;
    }
}
