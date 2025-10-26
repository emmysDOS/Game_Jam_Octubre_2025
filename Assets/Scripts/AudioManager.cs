using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSurce;
    [SerializeField] private AudioSource SFXSurce;
    
    [Header("Audio Clips")]
    public AudioClip music1;
    public AudioClip[] sfxClips;

    private void Start()
    {
        musicSurce.clip = music1;
        //musicSurce.loop = true;
        musicSurce.Play();
    }
}
