using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb2d;
	public Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {
	
		float timer = 0;
		
		while (knockDur > timer) {
			
			timer += Time.deltaTime;
			
			rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
		}
			
		yield return 0;
	}
}
