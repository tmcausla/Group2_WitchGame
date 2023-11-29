using UnityEngine;

public class ManaCollect : MonoBehaviour
{
    private readonly PlayerMana playerMana;
    [SerializeField] private float manaValue = 8;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMana>().AddMana(manaValue);
            Destroy(gameObject);
        }
    }
}
