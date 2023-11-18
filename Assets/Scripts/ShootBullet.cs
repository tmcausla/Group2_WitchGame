using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    //public PlayerMana playerMana;
    //private Camera mainCam;
    private Vector3 mousePos;
    public GameObject Prefab;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    //public int lessMana = 1;


    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        

        if (Input.GetMouseButtonDown(0) && canFire == true)
        {
            canFire = false;
            Instantiate(Prefab, bulletTransform.position, Quaternion.identity);
            //playerMana.UseMana(lessMana);

        }
        
    }
}
