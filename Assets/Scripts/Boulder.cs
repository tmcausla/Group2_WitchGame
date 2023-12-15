using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public GameObject health;
    public GameObject mana;
    private int chance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            DropItem();
        }
    }

    private void DropItem()
    {
        chance = Random.Range(1, 21);

        if (chance <= 4)
        {
             _ = Instantiate(health, transform.position, transform.rotation);
        }

        if  (chance >= 16)
        {
            _ = Instantiate(mana, transform.position, transform.rotation);
        }
    }
}
