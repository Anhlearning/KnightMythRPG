using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponInfo", menuName = "WeaponInfo", order = 0)]
public class WeaponInfo : ScriptableObject {
    public Transform weaponPrefab;
    public float weaponCountDown;    
}

