using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior2 : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody2D RBody2d;
    private Transform currentpoint;
    public float speed;
    public HealthSystem Health;
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {
        RBody2d = GetComponent<Rigidbody2D>();
        currentpoint = pointB.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentpoint.position - transform.position;
        if(currentpoint == pointB.transform)
        {
            RBody2d.velocity = new Vector2(speed, 0);
        }
        else
        {
            RBody2d.velocity = new Vector2(-speed, 0);
        }
        if(Vector2.Distance(transform.position, currentpoint.position)< 0.5f && currentpoint == pointB.transform)
        {
            currentpoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointA.transform)
        {
            currentpoint = pointB.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health.TakeDamage(dmg);
        }
    }
}
