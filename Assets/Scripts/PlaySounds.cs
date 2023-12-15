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
    public AudioClip damageEnemy;


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
    public void PlayBossImmuneSound() => soundManager.PlayOneShot(bossImmune);
    public void PlayBossHurt() => soundManager.PlayOneShot(bossHurt);
    public void PlayBossDeathSound() => soundManager.PlayOneShot(bossDeath);
    public void PlayLaserBeam() => soundManager.PlayOneShot(laserBeam);
    public void HurtEnemy() => soundManager.PlayOneShot(damageEnemy);
}
