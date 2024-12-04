using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem BulletEffect;

    public void PlayParticle()
    {
        BulletEffect.Play();
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayParticle();
    }
}
