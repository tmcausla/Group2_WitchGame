using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private PlaySounds sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<PlaySounds>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sm.PlayVictory();
            SceneManager.LoadScene(5);
        }
    }
}
