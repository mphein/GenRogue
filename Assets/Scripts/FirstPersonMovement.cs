using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    private float currSpeed;
    private float runSpeed;
    public float defaultSpeed = 6f;
    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Transform playerTransform;
    Vector3 velocity;
    bool isGrounded;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = transform;
        runSpeed = defaultSpeed * 2;
    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Input.GetKeyDown("space"))
        {
            Jump();
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currSpeed = runSpeed;
        } else currSpeed = defaultSpeed; 

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = playerTransform.forward * vertical + playerTransform.right * horizontal;

        direction.Normalize();


        controller.Move(direction * currSpeed * Time.deltaTime);
       

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        float jumpVel = Mathf.Sqrt(2 * jumpHeight * -gravity);

        velocity.y = jumpVel;
    }
}
