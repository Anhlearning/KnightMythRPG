using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private bool isAttack=true;
    private Player player;
    private Animator animator;
    [SerializeField]
    private float timetoAttack=0.25f;
    [SerializeField]
    private float timeAttackCountDown=0.5f;
    private float timerCountDown;
    private float timer=0f;
    void Awake()
    {
        playerInput=GetComponent<PlayerInput>();
        player=GetComponent<Player>();
        animator=GetComponent<Animator>();
    }
    private void Start() {
        playerInput.PlayerInputOnAttack += PlayerInput_OnAttack;
    }

    private void PlayerInput_OnAttack(object sender, EventArgs e)
    {
        Attack();
    }

    private void Attack()
    {   
        if(isAttack){
            timerCountDown+=Time.deltaTime;
            if(timerCountDown >= timeAttackCountDown){
                timerCountDown=0f;
                isAttack=true;
                animator.SetBool("isAttack",isAttack);
            }
        }
        else {
            isAttack=true;
            animator.SetBool("isAttack",isAttack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttack){
            timer += Time.deltaTime;
            if(timer >= timetoAttack){
                timer=0f;
                isAttack=false;
                animator.SetBool("isAttack",isAttack);
            }
        }
    }
    public bool IsAttack(){
        return isAttack;
    }
}
