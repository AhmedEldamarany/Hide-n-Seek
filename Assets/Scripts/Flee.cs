using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteerBehavior
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float fleeRange = 5;
    Vector3 awayPoint;
    
    protected override void SetDestination()
    {
        // SqrMagnitude is cheaper than distance
        if(Vector3.SqrMagnitude(target.position-transform.position)<fleeRange*fleeRange)
        {
            awayPoint = (transform.position - target.position) * 1.5f;
            agent.speed = 15;
            agent.SetDestination(awayPoint);
        }
        else
        {
            agent.speed = 0;
        }
    }
}
