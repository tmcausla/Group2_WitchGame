using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public Image[] manas;
    public float mana;
    public float maxMana = 8;

    public Sprite fullMana;
    public Sprite emptyMana;
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        maxMana = gm.playerMaxMana;
        mana = gm.playerMana;
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < manas.Length; i++)
        {
            manas[i].sprite = i < mana ? fullMana : emptyMana;
            manas[i].enabled = i < maxMana;
        }

        gm.playerMana = mana;
        gm.playerMaxMana = maxMana;
    }

    public void UseMana(int manaAmount) => mana = Mathf.Clamp(mana - manaAmount, 0, maxMana);

    public void AddMana(float manaValue) => mana = Mathf.Clamp(mana + manaValue, 0, maxMana);
}
