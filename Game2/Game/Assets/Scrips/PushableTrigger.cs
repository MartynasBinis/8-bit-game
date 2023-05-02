using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTrigger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isPressed = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pushable"))
        {
            isPressed = true;
            spriteRenderer.color = Color.green;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pushable"))
        {
            isPressed = false;
            spriteRenderer.color = Color.red;
        }
    }
}
