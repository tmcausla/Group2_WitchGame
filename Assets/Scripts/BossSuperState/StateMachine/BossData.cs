using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newBossData", menuName = "Data/Boss Data/Base Data")]
public class BossData : ScriptableObject
{
    [Header("Normal Chase")]
    public float normalSpeed = 5f;
    public float change = 2f;

    [Header("Range")]
    public float range = 5f;

    [Header("Normal Charge")]
    public float charge = 10f;

    [Header("Enraged Chase")]
    public float angryChase = 7f;

    [Header("Enraged Charge")]
    public float angryCharge = 13;
}
