using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem BulletEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayParticle()
    {
        BulletEffect.Play();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayParticle();
    }
}
