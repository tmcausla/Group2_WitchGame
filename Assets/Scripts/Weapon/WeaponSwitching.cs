using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            selectedWeapon += (scroll > 0f) ? -1 : 1;
            if (selectedWeapon < 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else if (selectedWeapon >= transform.childCount)
            {
                selectedWeapon = 0;
            }
        }

        for (int i = 0; i <= 3; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                selectedWeapon = i;
                break;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = -1;
        foreach (Transform weapon in transform)
        {
            i++;
            weapon.gameObject.SetActive(i == selectedWeapon);
        }
    }
}