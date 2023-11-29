using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public Image[] manas;
    public float mana;
    private readonly float maxMana = 8;
    private SpriteRenderer spriteRend;

    public Sprite fullMana;
    public Sprite emptyMana;

    // Start is called before the first frame update
    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        mana = maxMana;
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < manas.Length; i++)
        {
            manas[i].sprite = i < mana ? fullMana : emptyMana;
            manas[i].enabled = i < maxMana;
        }
    }

    public void UseMana(int manaAmount) => mana = Mathf.Clamp(mana - manaAmount, 0, maxMana);

    public void AddMana(float manaValue) => mana = Mathf.Clamp(mana + manaValue, 0, maxMana);
}
