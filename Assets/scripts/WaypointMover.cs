using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    //stores a reference to the waypoint system
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;

    [Range(0f, 15f)] // how fast the agent will rotate onece is reaches its waypoint
    [SerializeField] private float rotateSpeed = 4f;
    [SerializeField] private float distanceThreshold = 0.1f;


    // the current waypoint target that the object is moving towards.
    private Transform currentWaypoint;

    //rotation target for the current frame
    private Quaternion rotationGoal;

    //the direction of the next waypoint that the agent needs to rotate towards
    private Vector3 directionToWaypoint;




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
            //transform.LookAt(currentWaypoint);
        }
        RotateTowardsWaypoint();

    }
    // Will slowly rotate the agent towards the current waypoint it is moving towards
    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }

}
