using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCanonToPoint : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform pointer;
    private Vector3 targetOrtientation;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            pointer.position = raycastHit.point;
        }

        targetOrtientation = pointer.position - transform.position;

        transform.rotation = Quaternion.LookRotation(targetOrtientation);
    }

    public Vector3 GetOrientation()
    {
        return targetOrtientation;
    }

}
