using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGonContact : MonoBehaviour
{
    [SerializeField] protected int damage;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }
}
