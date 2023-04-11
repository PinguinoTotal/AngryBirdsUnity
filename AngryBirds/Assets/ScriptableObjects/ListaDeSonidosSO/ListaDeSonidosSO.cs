using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ListaDeSonidosSO : ScriptableObject
{
    public List<AudioClip> screams= new List<AudioClip>();
    public AudioClip bonk;
    public AudioClip explosion;
}
