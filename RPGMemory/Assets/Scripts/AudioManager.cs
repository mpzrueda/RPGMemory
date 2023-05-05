using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    
    [SerializeField] private AudioSource soundEffects;
    
    private void Awake ()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this; 
            DontDestroyOnLoad (this);
        }
    }

    private void Start() 
    {
        soundEffects = GetComponent<AudioSource>();
    }
    
    public void PlaySFX (AudioClip sfx)
    {
        soundEffects.PlayOneShot(sfx);
    }

    public void PlayMusic()
    {
        soundEffects.Play();
    }
}