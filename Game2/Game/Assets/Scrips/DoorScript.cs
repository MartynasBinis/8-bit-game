using UnityEngine;

public class DoorScript : MonoBehaviour
{
    PushableTrigger trigger;

    public float slideDistance = 1.5f;
    public float slideSpeed = 2.0f;
    public GameObject doorSpriteObject;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition - new Vector3(0, slideDistance, 0);
        trigger = GameObject.FindGameObjectWithTag("Trigger").GetComponent<PushableTrigger>();
    }

    void Update()
    {
        //if (isOpen)
        if (trigger.isPressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, slideSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, slideSpeed * Time.deltaTime);
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Pushable"))
    //    {
    //        isOpen = true;
    //        doorSpriteObject.SetActive(false);
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Pushable"))
    //    {
    //        isOpen = false;
    //        doorSpriteObject.SetActive(true);
    //    }
    //}
}