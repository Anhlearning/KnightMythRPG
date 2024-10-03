using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    [SerializeField]
    private TrailRenderer trailRenderer;

    private Vector2 movement;
    private Animator animator;
    private bool isDashing=false;
    private bool isFacing;
    private bool canMove;
    private float startSpeed;
    [SerializeField]
    private float moveSpeed=5f;
    [SerializeField]
    private float dashSpeed;
    private PlayerAimDir playerAimDir;
    private PlayerAttack playerAttack;

    protected override void Awake()
    {
        base.Awake();
        rb=GetComponent<Rigidbody2D>();
        playerInput=GetComponent<PlayerInput>();
        playerAttack=GetComponent<PlayerAttack>();
        animator=GetComponent<Animator>();
        playerAimDir=GetComponent<PlayerAimDir>();

    }
    private void Start() {
        startSpeed=moveSpeed;
        playerInput.playerInputOnDash += PlayerInput_OnDash;
    }

    private void PlayerInput_OnDash(object sender, EventArgs e)
    {
        Dash(); 
    }

    private void Dash()
    {
        if(!isDashing){
            isDashing=true;
            moveSpeed *=dashSpeed;
            trailRenderer.emitting=true;
            StartCoroutine(EndDashCourotine());
        }
    }
    private IEnumerator EndDashCourotine(){
        float dashTime=0.2f;
        float dashCD=1f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed=startSpeed;
        trailRenderer.emitting=false;
        yield return new WaitForSeconds(dashCD);
        isDashing=false;
    }

    // Update is called once per frame
    private void Update()
    {
        InputHandle();
    }
    private void FixedUpdate() {
        Move();
        HandleRotate(); 
    }
    private void HandleRotate(){
        if(!canMove){
            animator.SetFloat("AngelRotate",playerAimDir.getAngel());
        }
    }
    private void InputHandle(){
        movement=playerInput.GetMovementVectorNormolized();
        if(movement.magnitude !=0 && !playerAttack.IsAttack()){
            canMove=true;
            animator.SetBool("canMove",canMove);
        }
        else {
            canMove =false;
            animator.SetBool("canMove",canMove);
        }
    }
    private void Move(){
        if(canMove){
            animator.SetFloat("moveX",movement.x);
            animator.SetFloat("moveY",movement.y);
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }
    private void Flip(){
       isFacing=!isFacing;
       transform.Rotate(0,180f,0);
    }
}
