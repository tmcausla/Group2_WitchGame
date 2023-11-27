using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCollect : MonoBehaviour
{
    PlayerMana playerMana;
    [SerializeField] private float manaValue = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<PlayerMana>().AddMana(manaValue);
            Destroy(gameObject);
        }
    }
}
