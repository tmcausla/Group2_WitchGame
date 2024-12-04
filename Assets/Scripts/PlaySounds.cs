using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public static PlaySounds instance;
    public AudioSource soundManager;
    public AudioClip deathSound;
    public AudioClip getItem;
    public AudioClip bossImmune;
    public AudioClip bossHurt;
    public AudioClip bossDeath;
    public AudioClip laserBeam;
    public AudioClip enemyHurt;
    public AudioClip victory;
    public AudioClip bossFight;
    public AudioClip overworld;

    public Dictionary<string, AudioClip> AudioClipDictionary;

    private void Awake()
    {
        AudioClipDictionary = new()
        {
            { "deathSound", deathSound },
            { "getItem", getItem },
            { "bossImmune", bossImmune },
            { "bossHurt", bossHurt },
            { "laserBeam", laserBeam },
            { "enemyHurt", enemyHurt },
            { "victory", victory}
        };

        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void PlaySoundEffect(string audioClip)
    {
        if (AudioClipDictionary.ContainsKey(audioClip))
        {
            soundManager.PlayOneShot(AudioClipDictionary[audioClip]);
        }
    }

    public void ChangeMusic(AudioClip music)
    {
        soundManager.Stop();
        soundManager.clip = music;
        soundManager.Play();
    }
}