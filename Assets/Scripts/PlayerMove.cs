using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D avatarRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("up"))
        {
            avatarRigidbody.gravityScale = -1;
        }

        if (Input.GetButtonDown("down"))
        {
            avatarRigidbody.gravityScale = 1;
        }


    }
}
