using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] wayPoints;
    int wayPointIndex;
    Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = wayPoints[wayPointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWayPointIndex()
    {
        wayPointIndex = wayPointIndex + 1;

        if (wayPointIndex == wayPoints.Length)
        {
            wayPointIndex = 0;
        }

    }

}
