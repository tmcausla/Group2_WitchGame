using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    //public PlayerMana playerMana;
    public GameObject Prefab;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    //public int lessMana = 1;


    private void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
            }
        }
        

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Instantiate(Prefab, bulletTransform.position, Quaternion.identity);
            timer = 0;
            canFire = false;
            //playerMana.UseMana(lessMana);
        }
        
    }
}
