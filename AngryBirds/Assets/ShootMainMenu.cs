using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMainMenu : MonoBehaviour
{
    [SerializeField] ParticleSystem shootParticles;
    private AudioSource shootSound;
    [SerializeField] private float shootTime;
    [SerializeField] private float shootTimer;

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer>shootTime)
        {
            shootParticles.Play();
            shootSound.Play();
            shootTimer = 0;
        }
    }
}
