using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private PlaySounds sm;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 10, true);
        sm = FindObjectOfType<PlaySounds>();
        sm.PlaySoundEffect("laserBeam");
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
