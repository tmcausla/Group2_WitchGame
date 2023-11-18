using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootPlease : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    private void Update()
    {
        
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 shootDir = (mousePos - mainCam.transform.position).normalized;
        float rotZ = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
       
       
        
    }
}
