using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private bool hasKey = false;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            FindObjectOfType<PlaySounds>().PlayItemSound();
            Destroy(collision.gameObject);
            hasKey = true;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && hasKey)
        {
            FindObjectOfType<PlaySounds>().PlayDeathSound();
            Destroy(collision.gameObject);
        }
    }
}
