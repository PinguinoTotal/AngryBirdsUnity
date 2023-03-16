using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceUI : MonoBehaviour
{
    [SerializeField] private Button redButton;
    [SerializeField] private Button yellowButton;
    [SerializeField] private Button bombButton;
    [SerializeField] private ShootingCanon canon;

    private void Awake()
    {
        redButton.onClick.AddListener(() =>
        {
            canon.SetBalaADisparar(0);
        });
        yellowButton.onClick.AddListener(() =>
        {
            canon.SetBalaADisparar(1);
        });
        bombButton.onClick.AddListener(() =>
        {
            canon.SetBalaADisparar(2);
        });
    }
}
