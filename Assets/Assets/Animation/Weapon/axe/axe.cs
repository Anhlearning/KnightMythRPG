using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : IWeapon
{
    public void Attack()
    {
        Debug.Log("AXE");
        ActiveWeapon.Instance.ToggleAticeAttack(false);
    }
}
