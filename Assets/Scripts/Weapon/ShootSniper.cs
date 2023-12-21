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

    // Start is called before the first frame update
    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
        pauseMenu = FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
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
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring || playerMana.mana > 0)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (playerMana.mana <= 0)
        {
            canFire = false;
        }

        if (Input.GetMouseButtonDown(0) && canFire == true && pauseMenu.gamePaused)
        {
            canFire = false;
            _ = Instantiate(Prefab, bulletTransform.position, Quaternion.identity);
            playerMana.UseMana(lessMana);
        }
    }
}
