using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMovement : MonoBehaviour
{
    [Header("Animator Clip")]
    [Tooltip("Link to animator for game object")]
    public Animator animatorClip;

    [Header("Animation Parameters")]
    //[Tooltip("Link to animator for game object")]
    public string runningParameter = "Running";
    public string inTheAirParameter = "OnGround";
    public string jumpingParameter = "JumpUp";
    public string fallingParameter = "Falling";
    public string jumpButtonPressed = "JumpStart";

    [Header("Jump setup")]
    // the key used to activate the push
    public KeyCode key = KeyCode.Space;

    private bool canJump;

    private Rigidbody2D rigidBody;

    public bool running;
    private bool onGround;
    //private bool jumping;
    private bool falling;
    private bool jumpStart;
    public float verticalVelocity;
    public bool facingRight;
    public bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        running = false;
        onGround = true;
       // jumping = false;
        falling = false;
        jumpStart = false;
        rigidBody = GetComponent<Rigidbody2D>();
        animatorClip = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        verticalVelocity = rigidBody.velocity.y;

        if (verticalVelocity > 0.1f)
        {
            //jumping = true;
            falling = false;
            canJump = false;
            onGround = false;
        }
        else if (verticalVelocity < -0.5f)
        {
            //jumping = false;
            falling = true;
            canJump = false;
            onGround = false;
        }
        else
        {
           // jumping = false;
            falling = false;
            canJump = true;
            onGround = true;
        }

        if (!canJump)
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }

        if (Input.GetKeyDown(key))
        {
            jumpStart = true;
        }
        else
        {
            jumpStart = false;
        }

        if (horizontal != 0 && onGround)
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (horizontal > 0)
        {
            Vector3 thisScale = transform.localScale;
            if (thisScale.x < 0)
            {
                thisScale.x *= -1;
            }
            transform.localScale = thisScale;
            facingRight = true;
            facingLeft = false;
        }
        else if (horizontal < 0)
        {
            Vector3 thisScale = transform.localScale;
            if (thisScale.x > 0)
            {
                thisScale.x *= -1;
            }
            transform.localScale = thisScale;
            facingLeft = true;
            facingRight = false;
        }

        animatorClip.SetBool(runningParameter, running);
        animatorClip.SetBool(inTheAirParameter, onGround);
        //animatorClip.SetBool(jumpingParameter, jumping);
        animatorClip.SetBool(fallingParameter, falling);
        animatorClip.SetBool(jumpButtonPressed, jumpStart);
    }

}

