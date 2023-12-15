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
    private Transform upright;

    private void Awake()
    {
        upright = gameObject.transform;
    }

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

        if (chance <= 3)
        {
             _ = Instantiate(health, transform.position, upright.rotation);
        }

        if  (chance >= 17)
        {
            _ = Instantiate(mana, transform.position, upright.rotation);
        }
    }
}
