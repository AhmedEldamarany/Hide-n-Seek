using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : SteerBehavior
{
    
    float range = 50;
    Vector3 target;

    private void Start()
    {
        target = GetRandomPoint();
        agent.SetDestination(target);
        agent.speed = 5;
    }

    protected override void SetDestination()
    {
        if (agent.remainingDistance<2)
        {
            target = GetRandomPoint();
            agent.SetDestination(target);
        }
    }

    Vector3 GetRandomPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * range + transform.position;

        NavMeshHit hit; 

        NavMesh.SamplePosition(randomPos, out hit, range, NavMesh.AllAreas);
        return hit.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(target, 1);
    }
}
