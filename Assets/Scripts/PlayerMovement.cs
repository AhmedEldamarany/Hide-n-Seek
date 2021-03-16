using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    //private UiManager uiManager;
   //[SerializeField] VectorSO PlayerPosition;
    //[SerializeField] MyEventSO deathEvent;
    float h, v;
    public float speed = 5;
   //[SerializeField] private IntSo speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //uiManager = GameObject.FindGameObjectWithTag("ui").GetComponent<UiManager>();
    }

    
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal") * speed ;
        v = Input.GetAxis("Vertical") * speed ;
        rb.AddForce(h, 0, v);
       // PlayerPosition.value = transform.position;
       
    }
    public void Deadth()
    {
        //deathEvent.Raise();
        transform.position = new Vector3(0, 13, transform.position.z+3 );
        rb.velocity = Vector3.zero;
       // uiManager.TakeALife();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "deadly")
            Deadth();
    }
   
}

