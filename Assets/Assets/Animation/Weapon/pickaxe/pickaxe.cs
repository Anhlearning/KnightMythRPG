using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickaxe : IWeapon
{
    public void Attack()
    {
        Debug.Log("PICKAXE");
        ActiveWeapon.Instance.ToggleAticeAttack(false);
    }
}
