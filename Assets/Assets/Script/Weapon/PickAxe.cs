using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour,IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    public void Attack()
    {
        Debug.Log("PickAxe");
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    // Start is called before the first frame updat
}
