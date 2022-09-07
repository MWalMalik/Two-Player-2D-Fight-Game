using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // VARIABLES
    private float moveSpeed = 4;                        // controls speed on x-axis for running
    private float jumpSpeed = 8;                        // controls speed on y-axis for jumping 
    private Rigidbody2D playerRB2D;                         // to access player's assigned Rigidbody2D class component
    private float playerTransformX; // used to store initial GameObject's scale value at position X; can't be used directly due to continuous update of the value
    private float playerTransformY; // used to store initial GameObject's scale value at position Y; can't be used directly due to continuous update of the value
   private Animator playerAnimator;                   // to access assigned Animator class component

    public KeyCode left;                                // keyboard key for moving left
    public KeyCode right;                               // keyboard key for moving right
    public KeyCode jump;                                // keyboard key for jumping
    public KeyCode attack;                              // keybaord key for attacking
    public KeyCode crouch;                              // keybaord key for crouching

    public Transform groundCheck;                       // to access groundCheck's Transform class component
    private float groundCheckRadius = 0.02f;            // radius to verify if the GameObject groundCheck at the bottom is touching the "Ground" Layer
    public LayerMask groundLayer;                       // to access LayerMask for the "Ground" Layer

    private bool isTouchingGround;                      // used to stop player from jumping twice in air or to verify if player is on the ground

    //public float score;

    // START()
    void Start() {
        playerRB2D = GetComponent<Rigidbody2D>();           // accessing assigned Rigidbody2D class component
        playerTransformX = transform.localScale.x;      // storing initial value of gameobject's scale value at position X
        playerTransformY = transform.localScale.y;      // storing initial value of gameobject's scale value at position Y
        playerAnimator = GetComponent<Animator>();     // accessing assigned Animator class component
    }

// playeranimation
    // UPDATE()
    void Update() {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);   // returns "true" or "false" by checking if the player is on ground & used to limit player from jumping twice in air

        // Movement - Left:
        if (Input.GetKey(left) && !AnimatorIsPlaying("Attack") && !playerAnimator.GetBool("Crouch") && !playerAnimator.GetBool("Death")) {                             // if we don't use isAttackState and only lock constraints, the model will not move but run animation will run due to change in velocity
            playerRB2D.velocity = new Vector2(-moveSpeed, playerRB2D.velocity.y);       // moving the player in left direction
            transform.localScale = new Vector2(-playerTransformX, playerTransformY);                  // flipping the player in left direction
            GameManager.CameraState(left);
        }
        // Movement - Right
        else if (Input.GetKey(right) && !AnimatorIsPlaying("Attack") && !playerAnimator.GetBool("Crouch") && !playerAnimator.GetBool("Death")) {                       // if we don't use isAttackState and only lock constraints, the model will not move but run animation will run due to change in velocity
            playerRB2D.velocity = new Vector2(moveSpeed, playerRB2D.velocity.y);        // moving the player in right direction
            transform.localScale = new Vector2(playerTransformX, playerTransformY);                   // flipping the player in right direction
            GameManager.CameraState(right);
        }
        // Movement - Idle
        else {
            playerRB2D.velocity = new Vector2(0, playerRB2D.velocity.y);                // Stoping the player from moving in either direction
        }


        // // Jump
        if (Input.GetKeyDown(jump) && isTouchingGround && !AnimatorIsPlaying("Attack") && !playerAnimator.GetBool("Crouch") && !playerAnimator.GetBool("Death")) {
            playerRB2D.velocity = new Vector2(playerRB2D.velocity.x, jumpSpeed);        // Moving the player in upward direction
        }

        // // Attack
        if (Input.GetKeyDown(attack) && isTouchingGround && !AnimatorIsPlaying("Run") && !playerAnimator.GetBool("Death")) {
            playerAnimator.SetTrigger("Attack");                               // Triggering the "Attack" condition of Animator
            GameManager.Attack(attack);
        }

        // crouch
        if (Input.GetKeyDown(crouch) && isTouchingGround && !AnimatorIsPlaying("Run") && !playerAnimator.GetBool("Death")) {
            playerAnimator.SetBool("Crouch", true);          // will be used to start the Run animation
        }

        // Stand
        if (Input.GetKeyDown(jump) && isTouchingGround && playerAnimator.GetBool("Crouch") && !playerAnimator.GetBool("Death")) {
            playerAnimator.SetBool("Crouch", false);          // will be used to start the Run animation
        }

        // if (isTouchingGround && score <=0) {
        //     playerAnimator.SetBool("Death", true);          // will be used to start the Run animation
        // }

        // Triggering the "Speed" condition of Animator
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerRB2D.velocity.x));          // will be used to start the Run animation; using Mathf.Abs because speed needs to be positive for the animator condition to work

        // Triggering the "OnGround" condition of Animator
        playerAnimator.SetBool("OnGround", isTouchingGround);                  // will be used to start the Jump animation
    }


    // FUNCTIONS
    bool AnimatorIsPlaying(){
        return playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }

    bool AnimatorIsPlaying(string stateName){
        return AnimatorIsPlaying() && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

}