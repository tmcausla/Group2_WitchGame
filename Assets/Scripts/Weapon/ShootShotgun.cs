using UnityEngine;

public class ShootShotgun : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private GameManager gm;
    public PlayerMana playerMana;
    public GameObject Prefab;
    public Transform shotgunTransform;
    public Transform shotgunTransformTwo;
    public Transform shotgunTransformThree;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public int lessMana = 2;
    private MainMenu pauseMenu;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        pauseMenu = FindObjectOfType<MainMenu>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
        if (gm.unlockedSpells <= 1 || playerHealth.health <= 0)
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
            playerMana.UseMana(lessMana);
            _ = Instantiate(Prefab, shotgunTransform.position, shotgunTransform.rotation);
            _ = Instantiate(Prefab, shotgunTransformTwo.position, shotgunTransformTwo.rotation);
            _ = Instantiate(Prefab, shotgunTransformThree.position, shotgunTransformThree.rotation);
        }
    }
}
