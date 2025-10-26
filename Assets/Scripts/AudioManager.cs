using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSurce;
    [SerializeField] private AudioSource SFXSurce;
    
    [Header("Audio Clips")]
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip none;

    [SerializeField] private UI_Manager UI_Manager;
    [SerializeField] private bool painting;
    [SerializeField] private Input_Manager inputManager;
    [SerializeField] private PlayerController playerController;
    private void Start()
    {

        musicSurce.loop = true;
        //musicSurce.Play();

        //SFXSurce.Play();

    }
    private void Update()
    {
        if (playerController.paintingSelected)
        {
            painting = UI_Manager.painting;
            if (!painting && !inputManager.leftMouse)
            {
                musicSurce.clip = music2;
                musicSurce.Play();
            }
            else
            {
                SFXSurce.Stop();
                SFXSurce.clip = null;
            }
        }
        else
        {
            SFXSurce.Stop();
            SFXSurce.clip = null;
        }
            //SFXSurce.clip = none;

        


    }
}
