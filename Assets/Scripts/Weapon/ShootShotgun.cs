using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShotgun : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public UnlockShoot unlockShoot;
    public PlayerMana playerMana;
    public GameObject Prefab;
    public Transform shotgunTransform;
    public Transform shotgunTransformTwo;
    public Transform shotgunTransformThree;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public int lessMana = 1;
    private SpriteRenderer spriteRend;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.identity;
        if (unlockShoot.unlock <= 1 || playerHealth.health <= 0)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
        else
        {
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

            if (Input.GetMouseButtonDown(0) && canFire == true)
            {
                canFire = false;
                playerMana.UseMana(lessMana);
                Instantiate(Prefab, shotgunTransform.position, shotgunTransform.rotation);
                Instantiate(Prefab, shotgunTransformTwo.position, shotgunTransformTwo.rotation);
                Instantiate(Prefab, shotgunTransformThree.position, shotgunTransformThree.rotation);

            }
        }
    }


}
