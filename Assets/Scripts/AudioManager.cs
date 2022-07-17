using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private AudioSource audioSource;



    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    public float Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        audioSource.clip = s.clip;
        audioSource.volume = s.volume;
        audioSource.Play();
        return s.clip.length;
    }
}
