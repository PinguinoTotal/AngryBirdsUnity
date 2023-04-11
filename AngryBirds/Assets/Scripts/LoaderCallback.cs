using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool yaUpdate;
    private void Update()
    {
        if (!yaUpdate)
        {
            yaUpdate = true;
            Loader.CallBack();
        }
    }
}
