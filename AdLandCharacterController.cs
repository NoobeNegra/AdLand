using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdLandCharacterController : MonoBehaviour
{
    [Range(0f, 2f)]
    public float baseSpeed;
    public float raycastLenght;

    //Internal stuff
    private Rigidbody2D rb;
    private Animator animator;

    private Vector3 movementSpeed;
    private bool isAlive;

    private bool isJumping;
    private bool isJumpReleased;

    private bool jumpForceApplied; //Indicates if the jump force has been already applied
    private bool isAscending;

    private Vector2 jumpForce;
    private float jumpPressTime;

    private float jumpLastY; //Used to determine when the player is falling in a jump
    private float endTriggerHeight; //once the jump starts, the end animation will be played at this height from the ground
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        isAlive = true;

        isJumping = false;
        isJumpReleased = false;

        jumpForceApplied = false;
        isAscending = false;

        movementSpeed = new Vector3(baseSpeed, 0f, 0f);
        jumpForce = new Vector2(0f, 0f);
    }

    void Update()
    {
        //Just for preview reasons, keep assigning baseSpeed every frime
        movementSpeed.x = baseSpeed;

        //add fw movement
        transform.position += movementSpeed;

        //If character is not jumping already
        if (!isJumping)
        {
            //If jump was pressed on this frame, save the timestamp of this frame
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpPressTime = Time.time;
                //Do not prepare the jump unless it's a hold
            }
        }
        //The only thing to check once a jump has started is if the key is being released
        else if (!isJumpReleased)
        {
            //Check for how long it has been pressed. If longer than jump_preparationTime then play the preparation anim
            if (Time.time - jumpPressTime > Constants.jump_preparationTime)
            {
                //Player is charging the jump, play the preparation anim
                animator.SetInteger(Constants.anim_char_movementStatus, Constants.anim_char_jumpStatus_preparation);
            }

            //Jump when the player releases the key or the jump_maxHoldTime is exceeded
            if (Input.GetKeyUp(KeyCode.Space) || (Time.time - jumpPressTime > Constants.jump_maxHoldTime))
            {
                isJumpReleased = true;
                jumpForceApplied = false;
                //Calculate the force to apply
                float pressedTime = Mathf.Clamp(Time.time - jumpPressTime, 0f, 1f);
                //Use the pressed time as multiplier for the force
                jumpForce.y = Constants.jump_baseForce * (pressedTime + Constants.jump_minimumJump);

                Debug.Log("Pressed time>" + pressedTime + " JumpForce>" + jumpForce.y);
                //Determine how high it's going to start playing the end anim based on the jump force. The higher, the sooner
                if (jumpForce.y < 500f)
                {
                    endTriggerHeight = Constants.jump_endTriggerHeights[0];
                }
                else if (jumpForce.y < 750f)
                {
                    endTriggerHeight = Constants.jump_endTriggerHeights[1];
                }
                else
                {
                    endTriggerHeight = Constants.jump_endTriggerHeights[2];
                }

                //Player is charging the jump, play the preparation anim
                animator.SetInteger(Constants.anim_char_movementStatus, Constants.anim_char_jumpStatus_ascending);
            }
        }
    }

    void FixedUpdate()
    {
        //Check if character is alive, jumping and the key has been released
        if (isAlive && isJumping && isJumpReleased)
        {
            //If the force was already applied, check when to start falling
            if (jumpForceApplied)
            {
                //if the force was applied, check if it's ascending or descending
                if (isAscending)
                {
                    if (transform.position.y < jumpLastY)
                    {
                        isAscending = false;
                        Debug.Log("Descending started at +/-" + transform.position.y);
                    }
                    else
                    {
                        jumpLastY = transform.position.y;
                    }
                }
                //Once it's descending, start checking the endTriggerHeight 
                else if (transform.position.y <= endTriggerHeight)
                {
                    animator.SetInteger(Constants.anim_char_movementStatus, Constants.anim_char_jumpStatus_ending);
                }
            }
            //If force hasn't been applied, do it now!
            else
            {
                //Apply the needed force and trigger the right animation
                rb.AddForce(jumpForce);
                //Indicate the physical jump already happened
                jumpForceApplied = true;
                isAscending = true;
                jumpLastY = transform.position.y;
            }
        }
    }

    /// <summary>
    /// This method is called at the end of the fall animation to return to the running animation
    /// </summary>
    public void StopJumping()
    {
        isJumping = false;
        isJumpReleased = false;
        jumpForceApplied = false;
        animator.SetInteger(Constants.anim_char_movementStatus, Constants.anim_char_jumpStatus_running);

        //Check if jump was pressed during the jump and still is on hold at the end of the execution of the jump. 
        //If so re-start the jumpPressed timer but only here, after the first jump ends
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            jumpPressTime = Time.time;
        }
    }
}
/*
RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, raycastLenght, 1 << 9);
Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - raycastLenght, 0f), Color.red, 3f);
//If the raycast hits the ground
if (ground.collider != null)
{
    animator.SetInteger(Constants.anim_char_jumpStatus, Constants.anim_char_jumpStatus_ending);
    raycastGround = false;
    //The ending animation, at the end, has an event that calls the jump stop function.
}
*/
