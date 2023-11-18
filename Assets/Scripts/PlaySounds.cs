using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public static PlaySounds instance;
    public AudioSource soundManager;

    public AudioClip deathSound;
    public AudioClip getItem;


    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void PlayDeathSound()
    {
        soundManager.PlayOneShot(deathSound);
    }

    public void PlayItemSound()
    {
        soundManager.PlayOneShot(getItem);
    }
}
