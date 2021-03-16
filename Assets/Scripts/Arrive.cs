using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrive : SteerBehavior
{
    [SerializeField]
    Transform target;
    private int range = 10;

    protected override void SetDestination()
    {
     
        agent.SetDestination(target.position);
        if (agent.remainingDistance < range)
            agent.speed *= agent.remainingDistance / range;
        else
            agent.speed = originalspeed;
    }
}
