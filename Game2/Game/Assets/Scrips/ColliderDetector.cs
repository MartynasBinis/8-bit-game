using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public bool startTimer = false;
    public DissAContact aContact;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTimer = true;
        }
        else
        {
            startTimer = aContact.startTimer;
        }
    }   
}
