using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public struct Music
    {
        public string name;
        public AudioClip clip;
    }

    public static AudioManager Instance;
    public AudioSource audioSource;
    public Music[] audios;

    private void Awake()
    {
        Instance = this;
    }

    public void playSound(string name)
    {
        foreach (Music music in audios) {
            if (music.name == name)
            {
                audioSource.PlayOneShot(music.clip);
            }
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
