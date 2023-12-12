using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newBossData", menuName = "Data/Boss Data/Base Data")]
public class BossData : ScriptableObject
{
    [Header("Normal Chase")]
    public float normalSpeed = 10f;

    [Header("Range")]
    public float range = 5f;

    [Header("Normal Charge")]
    public float charge = 20f;

    [Header("Enraged Chase")]
    public float angryChase = 15f;

    [Header("Enraged Charge")]
    public float angryCharge = 30;
}
