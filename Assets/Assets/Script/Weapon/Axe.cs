using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe :MonoBehaviour, IWeapon
{   
    [SerializeField] private WeaponInfo weaponInfo;
    public void Attack()
    {
        Debug.Log("axe");
    }
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }
}
