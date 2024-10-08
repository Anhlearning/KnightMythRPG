using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour,IWeapon
{
    private Animator baseAnim;
    private float swordCD=0.5f;
    private void Awake() {
        baseAnim=GetComponentInChildren<Animator>();
    }
    public void Attack()
    {   
        baseAnim.SetBool("isAttack",true);
        baseAnim.SetFloat("AngelRotate",PlayerAimDir.Instance.getAngel());
        StartCoroutine(SwordCountDown());
    }
    IEnumerator SwordCountDown(){
        yield return new WaitForSeconds(swordCD);
        baseAnim.SetBool("isAttack",false);
        ActiveWeapon.Instance.ToggleAticeAttack(false);
        gameObject.SetActive(false);
    }
    
    
}
