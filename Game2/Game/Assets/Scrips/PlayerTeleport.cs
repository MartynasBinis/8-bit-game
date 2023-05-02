using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool inPortal=false;
    [SerializeField] private AudioSource teleportSound;
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.E)){
            if(currentTeleporter != null && inPortal != true){
                transform.position=currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                inPortal=true;
            }
            if(currentTeleporter == null){
                inPortal=false;
            }
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision){
            if(collision.CompareTag("Teleporter")){
                currentTeleporter=collision.gameObject;
                teleportSound.Play();
            }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Teleporter")){
            if(collision.gameObject==currentTeleporter){
                currentTeleporter=null;
                //inPortal=false;
            }
        }
    }
}
