using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    //stores a reference to the waypoint system
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;


    // the current waypoint target that the object is moving towards.
    private Transform currentWaypoint;



    // Start is called before the first frame update
    void Start()
    {
        // set intial position to the first waypoint
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //set the next waypoint target
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.LookAt(currentWaypoint);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }


    }
}
