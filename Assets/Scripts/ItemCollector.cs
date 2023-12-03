using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private bool hasKey = false;
    private PlaySounds sm;
    private GameManager gm;

    private void Awake()
    {
        sm = FindObjectOfType<PlaySounds>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        if (gm.newScene)
        {
            gm.playerCheckpoint = transform.position;
            gm.newScene = false;
        }
        transform.position = gm.playerCheckpoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            gm.playerCheckpoint = collision.gameObject.transform.position;
            sm.PlayItemSound();
            Destroy(collision.gameObject);
            hasKey = true;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            gm.newScene = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && hasKey)
        {
            sm.PlayDeathSound();
            Destroy(collision.gameObject);
            hasKey = false;
        }
    }
}
