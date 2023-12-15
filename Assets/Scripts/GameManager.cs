using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 playerCheckpoint;

    public bool newScene = false;

    public int unlockedSpells = 0;
    public float playerHealth = 8;
    public float playerMaxHealth = 8;
    public float playerMana = 8;
    public float playerMaxMana = 8;


    
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
