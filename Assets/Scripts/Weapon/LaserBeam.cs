using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private PlaySounds sm;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 10, true);
        sm = FindObjectOfType<PlaySounds>();
        sm.PlayLaserBeam();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LaserAttack()
    {
        Physics2D.IgnoreLayerCollision(6, 10, false);
    }
    public void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
