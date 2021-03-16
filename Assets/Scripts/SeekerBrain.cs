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
            direction.y = transform.position.y;
       


        if (distance < SqrRangeDistance)
        {
            if (Vector3.Angle(direction, transform.forward) < rangeAngle)
            {
                if (Physics.Raycast(transform.position, direction, rangeDistance, layer))
                {
                    Debug.DrawRay(transform.position, direction, Color.yellow);
                    isInRange = false;
                }
                else
                {
                    Debug.DrawRay(transform.position, direction, Color.white);
                isInRange = true;
                }

                Debug.Log("inRange");
            }
            else
                isInRange = false;
        }
        else
            isInRange = false;


        anim.SetBool("cansee", isInRange);

    }
   

}
