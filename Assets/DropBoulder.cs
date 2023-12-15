using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;

public class DropBoulder : MonoBehaviour
{
    private float timer;
    private int randomTime;
    public GameObject boulder;

    private void Start()
    {
        timer = Random.Range(15, 30);
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            _ = Instantiate(boulder, transform.position, transform.rotation);
            timer = Random.Range(7, 21);
        }
    }
}
