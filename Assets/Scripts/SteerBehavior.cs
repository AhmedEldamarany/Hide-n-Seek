using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class SteerBehavior : MonoBehaviour
{
    [SerializeField]
    bool behaviorEnabled = true;

    protected NavMeshAgent agent;
   // protected Animator anim;
    protected float originalspeed;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
      //  anim = GetComponent<Animator>();
        originalspeed = agent.speed; //needed it in the Arrive Script

    }

    protected virtual void Update()
    {
       // anim.SetFloat("Speed", agent.velocity.magnitude);

        NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 0, 0);
        Debug.Log(hit.distance);

        if (behaviorEnabled)
        {
            SetDestination();
        }
    }

    protected abstract void SetDestination();
}
