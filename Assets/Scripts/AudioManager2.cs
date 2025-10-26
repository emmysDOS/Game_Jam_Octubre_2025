using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    [SerializeField] private AudioSource musicSurce;
    public AudioClip music1;

    // Update is called once per frame
    private void Start()
    {
        musicSurce.clip = music1;   

        musicSurce.loop = true;
        musicSurce.Play();

    }
}
