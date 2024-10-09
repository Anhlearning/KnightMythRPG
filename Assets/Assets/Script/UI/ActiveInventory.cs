using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotCurrent;
    // Update is called once per frame
    void Start()
    {   
       PlayerInput.Instance.PlayerInputActiveSlotInventory += ActiveInventory_ActiveSlot;
       ToggleActiveSlot(0);
    }

    private void ActiveInventory_ActiveSlot(object sender, PlayerInput.IndexActiveEventArgs e)
    {
        ToggleActiveSlot(e.indexActive-1);
    }

    private void ToggleActiveSlot(int indexActive){
        activeSlotCurrent=indexActive;
        foreach(Transform child in gameObject.transform){
            child.GetChild(1).gameObject.SetActive(false);
        }
        transform.GetChild(activeSlotCurrent).GetChild(1).gameObject.SetActive(true);
        ChangeActiveWeapon();
    }
    private void ChangeActiveWeapon(){
        if(ActiveWeapon.Instance.WeaponCurrent != null){
            Destroy(ActiveWeapon.Instance.WeaponCurrent.gameObject);
        }
        if(transform.GetChild(activeSlotCurrent).GetComponent<InventorySlot>()==null){
            ActiveWeapon.Instance.WeaponNull();
            return;
        }
        Transform weaponActive=transform.GetChild(activeSlotCurrent).GetComponent<InventorySlot>().GetWeaponInfo().weaponPrefab;
        Transform weaponSpwan=Instantiate(weaponActive,ActiveWeapon.Instance.transform.position,Quaternion.identity);
        weaponSpwan.parent=ActiveWeapon.Instance.transform;
        ActiveWeapon.Instance.NewWeapon(weaponSpwan);
    }
}
