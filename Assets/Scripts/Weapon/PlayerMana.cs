using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMana : MonoBehaviour
{
    public Image[] manas;
    public float mana;
    private float maxMana = 8;
    private SpriteRenderer spriteRend;


    public Sprite fullMana;
    public Sprite emptyMana;
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < manas.Length; i++)
        {
            if (i < mana)
            {
                manas[i].sprite = fullMana;
            }
            else
            {
                manas[i].sprite = emptyMana;
            }
            if (i < maxMana)
            {
                manas[i].enabled = true;
            }
            else
            {
                manas[i].enabled = false;
            }
        }
    }

    public void UseMana(int manaAmount)
    {
        mana = Mathf.Clamp(mana - manaAmount, 0, maxMana);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
    public void AddMana(float manaValue)
    {

        mana = Mathf.Clamp(mana + manaValue, 0, maxMana);
    }
}
