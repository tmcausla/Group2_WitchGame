using UnityEngine;

public class Despawn : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject,5);
    }
}
