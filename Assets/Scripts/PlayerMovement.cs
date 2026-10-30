using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float crouchSpeed = 2.5f;
    
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    public float standingHeight = 1.8f;
    public float crouchingHeight = 1.0f;
    public float heightChangeSpeed = 6f;

    //keys
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;

    CharacterController cc;
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        if (cc == null)
        {
            cc = gameObject.AddComponent<CharacterController>();
        }
        cc.height = standingHeight;
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        isGrounded = cc.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        float currentSpeed = walkSpeed;
        if (Input.GetKey(runKey))
        {
            currentSpeed = runSpeed;
        }

        //crouch
        if (Input.GetKey(crouchKey))
        {
            currentSpeed = crouchSpeed;
            cc.height = crouchingHeight;
        }
        else
        {
            cc.height = standingHeight;
        }

        //apply gravity
        velocity.y += gravity * Time.deltaTime;

        //jump
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //move with horizontal + vertical velocity
        cc.Move((move * currentSpeed + velocity) * Time.deltaTime);
    }
}
