using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private float activeMoveSpeed;
    [SerializeField]
    private float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCooldownCounter;
    private SpriteRenderer sprite;

    private Animator ninjaAnim;

    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();  
        sprite = GetComponent<SpriteRenderer>();    
        ninjaAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

       

        rb.velocity = moveInput * activeMoveSpeed;
        if (rb.velocity.magnitude > 0)
        {
            ninjaAnim.SetBool("moving", true);
        } else
        {
            ninjaAnim.SetBool("moving", false);
        }
       
        if (moveInput.x < 0)
        {
            sprite.flipX = true;
        }

        if (moveInput.x > 0)
        {
            sprite.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }

        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }
    }
}
