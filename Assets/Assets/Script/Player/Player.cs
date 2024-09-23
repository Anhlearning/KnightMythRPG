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

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        playerInput=GetComponent<PlayerInput>();
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
        animator.SetFloat("AngelRotate",playerAimDir.getAngel());
    }
    private void InputHandle(){
        movement=playerInput.GetMovementVectorNormolized();

        animator.SetFloat("moveX",movement.x);
        animator.SetFloat("moveY",movement.y);
        animator.SetFloat("Speed",movement.magnitude);

        // if(movement !=Vector2.zero){
        //     animator.SetBool("canMove",true);
        // }
        // else {
        //     animator.SetBool("canMove",false);
        // }
        // if(movement.x <0 && isFacing){
        //     Flip();
        // }
        // if(movement.x >0 && !isFacing) {
        //     Flip();
        // }
        // // Debug.Log(movement);
    }
    private void Move(){
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    private void Flip(){
       isFacing=!isFacing;
       transform.Rotate(0,180f,0);
    }
}
