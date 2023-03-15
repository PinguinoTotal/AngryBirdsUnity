using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform pointer;
    [SerializeField] private Transform bocaDeCanon;
    [SerializeField] private ListBulletsSO listBulletsSO;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            pointer.position = raycastHit.point;
        }

        Vector3 targetOrtientation = pointer.position-transform.position;

        transform.rotation = Quaternion.LookRotation(targetOrtientation);
    }
}
