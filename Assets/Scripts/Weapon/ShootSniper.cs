using UnityEngine;

public class ShootSniper : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private GameManager gm;
    public PlayerMana playerMana;
    public GameObject Prefab;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public int lessMana = 1;
    private SpriteRenderer spriteRend;
    private MainMenu pauseMenu;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
        pauseMenu = FindObjectOfType<MainMenu>();
    }

    private void Update()
    {
        if (gm.unlockedSpells <= 2 || playerHealth.health <= 0)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }

        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

        if (playerMana.mana <= 0)
        {
            canFire = false;
        }
        else if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire == true && !pauseMenu.gamePaused)
        {
            canFire = false;
            _ = Instantiate(Prefab, bulletTransform.position, Quaternion.identity);
            playerMana.UseMana(lessMana);
        }
    }
}
