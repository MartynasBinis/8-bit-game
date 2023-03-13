using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpPower = 5;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    //main object variable
    private Rigidbody2D duck;
    // animatio variable
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    //left right movement input
    private float horizontalInput;

    // Start is called before the first frame update
    void Awake()
    {
        duck = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //left and right movement
        horizontalInput = Input.GetAxis("Horizontal");


        duck.velocity = new Vector2(horizontalInput * speed, duck.velocity.y);

        //jump mech
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }

        // turn sprite to right side
        if (horizontalInput > 0.01f) transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (horizontalInput < -0.01f) transform.localRotation = Quaternion.Euler(0, 180, 0);
        //animation for running and jump
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());


        //wall jump mech
        if (wallJumpCooldown > 0.2f)
        {


            duck.velocity = new Vector2(horizontalInput * speed, duck.velocity.y);

            if (onWall() && !isGrounded() && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)))
            {
                duck.gravityScale = 0;
                duck.velocity = Vector2.zero;
            }
            else
            {
                duck.gravityScale = 1;
            }
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
        dontAllowWallJumpOnGroundObjects();

    }
    // jumping + wall jump logic
    private void Jump()
    {
        if (isGrounded())
        {
            duck.velocity = new Vector2(duck.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                duck.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 6);
                duck.velocity = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {

                duck.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCooldown = 0;
        }

    }
    // Temporary fix
    private void dontAllowWallJumpOnGroundObjects()
    {
        if (touchingGroundLeft() || touchingGroundRight())
        {
            duck.gravityScale = 10;
        }

    }
    //checks if player has collision with ground
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    //check if player has collision with wall
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    private bool touchingGroundLeft()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.left, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool touchingGroundRight()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
