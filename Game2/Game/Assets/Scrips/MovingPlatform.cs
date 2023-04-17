using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;

    private Transform targetWaypoint;
    private int currentWaypoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetWaypoint = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
                transform.position,
                targetWaypoint.position,
                speed * Time.deltaTime

            );

        if (Vector2.Distance(transform.position,targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoints();
        }
    }

    private Transform GetNextWaypoints()
    {
        currentWaypoint++;
        if(currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
        return waypoints[currentWaypoint];
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var platformMovement = other.collider.GetComponent<Movement>();
        if (platformMovement != null)
        {
            platformMovement.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        var platformMovement = other.collider.GetComponent<Movement>();
        if (platformMovement != null)
        {
            platformMovement.ResetParent();
        }
    }
}
