using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int keys = 0;
    [SerializeField] private float healthValue;
    private PlaySounds sm;
    private GameManager gm;

    private void Awake()
    {
        sm = FindObjectOfType<PlaySounds>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        //Pulls most recent checkpoint from GameManager
        if (gm.newScene)
        {
            gm.playerCheckpoint = transform.position;
            gm.newScene = false;
        }
        transform.position = gm.playerCheckpoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When player picks up a key
        if (collision.gameObject.CompareTag("Key"))
        {
            gm.playerCheckpoint = collision.gameObject.transform.position; //updates checkpoint position in GameManager
            sm.PlayItemSound();
            Destroy(collision.gameObject);
            keys++;
        }

        //When player reaches the end of level
        if (collision.gameObject.CompareTag("Finish"))
        {
            gm.newScene = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //When player unlocks a new spell
        if (collision.gameObject.CompareTag("MoreWeapon"))
        {
            Destroy(collision.gameObject);
            gm.unlockedSpells++;
        }

        //When player picks up health
        if (collision.tag == "Health")
        {
            gameObject.GetComponent<PlayerHealth>().AddHealth(healthValue);
            Destroy(collision.gameObject);
        }

        //When player picks up mana
        if (collision.tag == "Mana")
        {
            gameObject.GetComponent<PlayerMana>().mana = gameObject.GetComponent<PlayerMana>().maxMana;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When player encounters a door
        if (collision.gameObject.CompareTag("Door") && keys > 0)
        {
            sm.PlayDeathSound();
            Destroy(collision.gameObject);
            keys--;
        }
    }
}
