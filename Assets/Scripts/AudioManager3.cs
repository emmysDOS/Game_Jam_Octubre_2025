using UnityEngine;

public class AudioManager3 : MonoBehaviour
{
    [SerializeField] private AudioSource musicSurce;
    public AudioClip music1;
    public AudioClip none;

    [SerializeField] private UI_Manager UI_Manager;

    // Update is called once per frame
    private void Update()
    {

        

        
    }
    public void PlaySound()
    {
        musicSurce.clip = music1;

        musicSurce.loop = false;
        musicSurce.Play();
    }
}
