using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex/2 == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeapon >= 2)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon <= 0)
            {
                currentWeapon = 2;
            }
            else
            {
                currentWeapon--;
            }
        }
    }
}
