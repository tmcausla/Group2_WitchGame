using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 playerCheckpoint;

    public bool newScene = false;

    public int unlockedSpells = 0;


    
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);

        playerCheckpoint = GameObject.FindWithTag("Player").transform.position;
    }
}
