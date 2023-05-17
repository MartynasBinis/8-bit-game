using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpPower = 5;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource itemPickupSound;
    [SerializeField] private AudioSource changeModeSound;
    //main object variable
    private Rigidbody2D duck;
    // animatio variable
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    //left right movement input
    private float horizontalInput;
    private Transform originalParent;
    public static bool gravityOn = false;
    bool gravityOff = true;
    bool upGravity = false;
    public static bool hasGravity = false;
    public static bool enteredGravityZone = false;
    private bool soundPlayed1 = false;
    private bool soundPlayed2 = false;

    // Start is called before the first frame update
    void Awake()
    {
        duck = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalParent = transform.parent;
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

        else if (!upGravity)
        {

            if (horizontalInput > 0.01f) transform.localRotation = Quaternion.Euler(0, 0, 0);
            else if (horizontalInput < -0.01f) transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        // turn sprite to right side + gravity if on
        if (upGravity)
        {

            if (horizontalInput > 0.01f) transform.localRotation = Quaternion.Euler(180, 0, 0);
            else if (horizontalInput < -0.01f) transform.localRotation = Quaternion.Euler(180, 180, 0);
        }

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



        if(enteredGravityZone)
        {
            
            if (hasGravity) Gravity();
            else Physics2D.gravity = new Vector2(0, -9.8f);
        }
        if(!enteredGravityZone)
        {
            gravityOn = false;
            gravityOff = true;
            if(upGravity)
            {
                upGravity = false;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                Physics2D.gravity = new Vector2(0, -9.8f);
            }
        }
        print(hasGravity + "   HasGravity");
        print(gravityOff + "   GravityOff");
        print(gravityOn + "   GravityOn");
        print(enteredGravityZone + "   GravityZone");
    }
    private void Gravity()
    {
        
        if (!gravityOff && Input.GetKeyDown(KeyCode.G))
        {
            gravityOff = true;
            soundPlayed1 = false;
            soundPlayed2 = false;
        }
        else if (gravityOff && Input.GetKeyDown(KeyCode.G))
        {
            gravityOff = false;
            soundPlayed1 = false;
            soundPlayed2 = false;
        }

        if (!gravityOff)
        {
            if (Input.GetKey(KeyCode.S))
            {
                soundPlayed2 = false;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                Physics2D.gravity = new Vector2(0, -9.8f);
                upGravity = false;
                if (!soundPlayed1)
                {
                    changeModeSound.Play();
                    soundPlayed1 = true;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                soundPlayed1 = false;
                transform.localRotation = Quaternion.Euler(180, 0, 0);
                upGravity = true;
                Physics2D.gravity = new Vector2(0, 9.8f);
                if (!soundPlayed2)
                {
                    changeModeSound.Play();
                    soundPlayed2 = true;
                }
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gravity")
        {
            collision.gameObject.SetActive(false);
            gravityOn = true;
            hasGravity = true;
            itemPickupSound.Play();
        }

    }
    // jumping + wall jump logic
    private void Jump()
    {
        if (isGrounded())
        {
            duck.velocity = new Vector2(duck.velocity.x, jumpPower);
            anim.SetTrigger("jump");
            jumpSound.Play();
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
            jumpSound.Play();
        }

    }
    // Temporary fix
    private void dontAllowWallJumpOnGroundObjects()
    {
        if (touchingGroundLeft() || touchingGroundRight())
        {
            duck.gravityScale = 5;
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
    public void SetParent(Transform newParent)
    {
        originalParent = transform.parent;
        transform.parent = newParent;
    }

    public void ResetParent()
    {
        transform.parent = originalParent;
    }
}