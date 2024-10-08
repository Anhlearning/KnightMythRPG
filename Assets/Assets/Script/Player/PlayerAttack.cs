using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator=GetComponent<Animator>();
    }
    private void Start() {
        ActiveWeapon.Instance.ToggleAnimPlayer += PlayerAttack_Toggle;
    }

    private void PlayerAttack_Toggle(object sender, EventArgs e)
    {
        animator.SetBool("isAttack",true);
        StartCoroutine(ResetAnimationFromAttack());
    }
    IEnumerator ResetAnimationFromAttack(){
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isAttack",false);
    }
}
