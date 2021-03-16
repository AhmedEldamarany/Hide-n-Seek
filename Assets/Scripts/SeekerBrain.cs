using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerBrain : MonoBehaviour
{
    [SerializeField] Transform Player;
    Animator anim;
    private Vector3 direction;
    private float rangeAngle = 90f;
    private int rangeDistance = 5;
    [SerializeField] LayerMask layer;
    private int SqrRangeDistance;
    private float distance;
    private bool isInRange = false;

    public Vector3 getPlayerPosition()
    {
        return Player.position;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        SqrRangeDistance = rangeDistance * rangeDistance;
    }


    private void FixedUpdate()
    {
       
            direction = Player.position - this.transform.position;
            distance = Vector3.SqrMagnitude(direction);
            if (distance < SqrRangeDistance)
            {
                if (Vector3.Angle(direction, transform.forward) < rangeAngle)
                {

                    //if (Physics.Raycast(transform.position, direction, rangeDistance, layer))
                    //{// need to use actual distance so that it only detect the blockers between the npc and player
                    //    Debug.DrawRay(transform.position, direction * rangeDistance, Color.yellow);
                    //    anim.SetBool("cansee", false);

                    //}
                    //else
                    //{
                    //    Debug.DrawRay(transform.position, direction * rangeDistance, Color.white);
                    //    anim.SetBool("cansee", true);
                    //}
                    isInRange = true;
                }
                else
                    isInRange = false;
            }
            else
                isInRange = false;

        
        anim.SetBool("cansee", isInRange);

    }

}
