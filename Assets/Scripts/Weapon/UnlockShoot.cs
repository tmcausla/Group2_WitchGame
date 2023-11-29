using UnityEngine;

public class UnlockShoot : MonoBehaviour
{
    public int unlock = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MoreWeapon"))
        {
            Destroy(collision.gameObject);
            unlock++;
        }
    }
}
