using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private SpriteRenderer playerSprite;
    private Vector2 movement;
    private Animator animator;
    private bool isFacing;
    private bool canMove;
    [SerializeField]
    private float moveSpeed=5f;
    private PlayerAimDir playerAimDir;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        playerInput=GetComponent<PlayerInput>();
        playerAttack=GetComponent<PlayerAttack>();
        playerSprite=GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
        playerAimDir=GetComponent<PlayerAimDir>();
    }
    private void Start() {

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
