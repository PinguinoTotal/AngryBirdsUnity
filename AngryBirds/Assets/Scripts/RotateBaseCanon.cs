using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBaseCanon : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform pointer;
    [SerializeField] private LayerMask layerMask;
    private float altura = 21f;
    private Vector3 targetOrtientation;
    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            pointer.position = raycastHit.point;
        }

        Vector3 pointerFixed = new Vector3(pointer.position.x, altura, pointer.position.z);

        targetOrtientation = pointerFixed - transform.position;

        transform.rotation = Quaternion.LookRotation(targetOrtientation);
    }

    public Vector3 GetOrientation()
    {
        return targetOrtientation;
    }
}
