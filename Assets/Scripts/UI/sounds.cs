using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class sounds
{
    public AudioClip clip;
    public string name;
    [HideInInspector]
    public AudioSource source;

    [Range(0,1)]
    public float volume;

    [Range(.1f, 3)]
    public float pitch;
}
