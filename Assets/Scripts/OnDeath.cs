using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public GameObject Orb;

    public void CreateOrb()
    {
        Instantiate(Orb, transform.position, Quaternion.identity);
    }
}
