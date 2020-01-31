using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    Rigidbody2D rigidbody2D;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    Animator animator;
    string lastFacingPosition;

    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * movementSpeed;
    }

    private void ChangeAnimation() {
        string animationToPlay = "";
        if (horizontalMove < 0) {
            animationToPlay = "PlayerWalkingLeft";
            lastFacingPosition = "left";
        } else if (horizontalMove > 0) {
            animationToPlay = "PlayerWalkingRight";
            lastFacingPosition = "right";
        } else if (verticalMove > 0) {
            animationToPlay = "PlayerWalkingUp";
            lastFacingPosition = "up";
        } else if (verticalMove < 0) {
            animationToPlay = "PlayerWalkingDown";
            lastFacingPosition = "down";
        } else if (horizontalMove == 0 && verticalMove == 0) {
            switch(lastFacingPosition) {
                case "left":
                    animationToPlay = "PlayerIdleLeft";
                    break;
                case "right":
                    animationToPlay = "PlayerIdleRight";
                    break;
                case "down":
                    animationToPlay = "PlayerIdleDown";
                    break;
            }
        }
        animator.Play(animationToPlay);
    }

    void FixedUpdate() {
        Vector2 movement = new Vector2(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
        rigidbody2D.MovePosition(movement);
        ChangeAnimation();
    }
}
