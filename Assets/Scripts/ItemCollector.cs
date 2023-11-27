using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private bool hasKey = false;
    private PlaySounds sm;

    private void Start()
    {
        sm = FindObjectOfType<PlaySounds>();
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            sm.PlayItemSound();
            Destroy(collision.gameObject);
            hasKey = true;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && hasKey)
        {
            sm.PlayDeathSound();
            Destroy(collision.gameObject);
        }
    }
}
