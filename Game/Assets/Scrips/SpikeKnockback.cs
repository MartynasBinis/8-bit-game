using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeKnockback : MonoBehaviour
{
	private HealthSystem health;
	private Player player;
	
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player")
		{
			health.TakeDamage(1);
			StartCoroutine(player.Knockback(0.02f, -1000, player.transform.position));
		}
	}
}
