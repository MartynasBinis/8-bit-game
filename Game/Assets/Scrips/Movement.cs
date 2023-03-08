using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Rigidbody2D duck;
    private bool ground;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        duck = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        
        duck.velocity = new Vector2(horizontalInput * speed, duck.velocity.y);

        if (Input.GetKey(KeyCode.Space) && ground)
        {
            Jump();
        }

        if (horizontalInput > 0.01f) transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (horizontalInput < -0.01f) transform.localRotation = Quaternion.Euler(0, 180, 0);

        anim.SetBool("run",horizontalInput !=0);
        anim.SetBool("grounded", ground);
    }

    private void Jump()
    {
        duck.velocity = new Vector2(duck.velocity.x, speed);
        anim.SetTrigger("jump");
        ground = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }
}

