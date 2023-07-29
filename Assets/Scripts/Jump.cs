using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // strength of the push
    public float jumpStrength = 10f;

    private bool canJump;

    private Rigidbody2D rigidBody;
    public float yVelocity;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity = rigidBody.velocity.y;

        if (rigidBody.velocity.y == 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (canJump && Input.GetButton("Jump"))
        {
            // Apply an instantaneous upwards force
            rigidBody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            
            //canJump = !checkGround;
        }
        if(!canJump && Input.GetButton("Jump") && yVelocity > 10.0f){
            rigidBody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Force);
        }

    }

}
