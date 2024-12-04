using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int keys = 0;
    [SerializeField] private float healthValue;
    private PlaySounds sm;
    private GameManager gm;
    private Animator anim;

    private void Awake()
    {
        sm = FindObjectOfType<PlaySounds>();
        gm = FindObjectOfType<GameManager>();
        anim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
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
        PlayerMana playerMana = gameObject.GetComponent<PlayerMana>();
        PlayerHealth playerHealth = gameObject.GetComponent<PlayerHealth>();

        switch (collision.gameObject.tag)
        {
            case "Key":
                gm.playerCheckpoint = collision.gameObject.transform.position; //updates checkpoint position in GameManager
                sm.PlaySoundEffect("getItem");
                keys++;
                Destroy(collision.gameObject);
                break;
            case "Finish":
                gm.newScene = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "MoreWeapon":
                gm.unlockedSpells++;
                playerMana.mana = playerMana.maxMana;
                Destroy(collision.gameObject);
                break;
            case "Health":
                playerHealth.AddHealth(healthValue);
                Destroy(collision.gameObject);
                break;
            case "Mana":
                playerMana.mana = playerMana.maxMana;
                Destroy(collision.gameObject);
                break;
            case "CameraPull":
                anim.SetTrigger("cameraPull");
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When player encounters a door
        if (collision.gameObject.CompareTag("Door") && keys > 0)
        {
            sm.PlaySoundEffect("deathSound");
            keys--;
            Destroy(collision.gameObject);
        }
    }
}
