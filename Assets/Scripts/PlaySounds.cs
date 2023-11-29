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
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void PlayDeathSound() => soundManager.PlayOneShot(deathSound);

    public void PlayItemSound() => soundManager.PlayOneShot(getItem);
}
