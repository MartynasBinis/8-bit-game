using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    public int dmg;
    public Rigidbody2D myRigidBody;
    public HealthSystem Health;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (IsFacingRight()) //move right
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else // move left
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }   
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)),transform.localScale.y);
        if (collision.CompareTag("Player"))
        {
            Health.TakeDamage(dmg);
        }
    }
}
