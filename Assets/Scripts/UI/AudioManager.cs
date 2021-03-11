using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public sounds[] AudioSounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (sounds s in AudioSounds){
            s.source = gameObject.GetComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        sounds s = Array.Find(AudioSounds, sounds => sounds.name == name);
        s.source.Play();
    }
}
