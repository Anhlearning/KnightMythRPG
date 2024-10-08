using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlot;
    // Update is called once per frame
    void Start()
    {   
       PlayerInput.Instance.PlayerInputActiveSlotInventory += ActiveInventory_ActiveSlot;
    }

    private void ActiveInventory_ActiveSlot(object sender, PlayerInput.IndexActiveEventArgs e)
    {
        ToggleActiveSlot(e.indexActive-1);
    }

    private void ToggleActiveSlot(int indexActive){
        activeSlot=indexActive;
        foreach(Transform child in gameObject.transform){
            child.GetChild(1).gameObject.SetActive(false);
        }
        transform.GetChild(activeSlot).GetChild(1).gameObject.SetActive(true);
    }
}
