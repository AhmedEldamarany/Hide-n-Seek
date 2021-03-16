using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeekingBehaviour : StateMachineBehaviour
{
    protected GameObject NPC;
    protected NavMeshAgent agent;
    protected  Vector3  target;

    float rangeToChase = 50;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        agent = NPC.GetComponent<NavMeshAgent>();
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    protected Vector3 GetRandomPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * rangeToChase + NPC.transform.position;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, rangeToChase, NavMesh.AllAreas);
        return hit.position;
    }
}
