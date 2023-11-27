using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SeePlayer : MonoBehaviour
{

    public Transform playerTransform;
    public GameObject Arrow;
    public bool isSeeing;
    public float seeDistance;
    public float countDown;
    public float countDownOver;
    public bool shooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlipPosition();
        if (shooting == false)
        {
            countDown += Time.deltaTime;
            if (countDown > countDownOver)
            {
                shooting = true;
                countDown = 0;
            }
        }
        if (isSeeing == true && shooting == true)
        {
            ShootPlayer();
            shooting = false;
        }
        else
        {
            isSeeing = false;
            if (Vector2.Distance(transform.position, playerTransform.position) < seeDistance)
            {
                isSeeing = true;
            }
            else
            {
                isSeeing = false;
            }
        }
    }

    private void ShootPlayer()
    {
        Instantiate(Arrow, transform.position, transform.rotation);
        shooting = false;
    }
    private void FlipPosition()
    {
        if (transform.position.x > playerTransform.position.x && isSeeing == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (transform.position.x < playerTransform.position.x && isSeeing == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
