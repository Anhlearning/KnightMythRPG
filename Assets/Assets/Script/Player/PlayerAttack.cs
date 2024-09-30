using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private bool isAttack=false;
    private bool canAttack;
    private Player player;
    private Animator animator;
    [SerializeField]
    private float timeAttackCountDown=0.5f;
    void Awake()
    {
        playerInput=GetComponent<PlayerInput>();
        player=GetComponent<Player>();
        animator=GetComponent<Animator>();
    }
    private void Start() {
        playerInput.PlayerInputOnAttack += PlayerInput_OnAttack;
        playerInput.PlayerInputCancelAttack+= PlayerInput_CanAttack;
    }

    private void PlayerInput_CanAttack(object sender, EventArgs e)
    {
        canAttack=false;
    }

    private void PlayerInput_OnAttack(object sender, EventArgs e)
    {
        canAttack=true;
    }

    private void Attack()
    {   
        if(canAttack && !isAttack){
            isAttack=true;
            animator.SetBool("isAttack",isAttack);
            StartCoroutine(CountDownAttack());
        }
    }
    private IEnumerator CountDownAttack(){
        yield return new WaitForSeconds(timeAttackCountDown);
        isAttack=false;
        animator.SetBool("isAttack",isAttack);
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    public bool IsAttack(){
        return isAttack;
    }
}
