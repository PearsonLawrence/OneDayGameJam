using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour {

    private Vector3 target;
    
    public float radius;
    
    public float jitter;
   
    public float distance;
    private Vector3 steeringForce;
    Rigidbody rb;
    
    public float Force;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DoWander()
    {

        target = Vector3.zero;


        //Random.InitState((int)transform.position.x);

        target = Random.insideUnitCircle.normalized * radius;


        target = (Vector2)target + Random.insideUnitCircle * jitter;
        target = target.normalized * radius;


        target.z = target.y;
        target.y = 0.0f;
        target += transform.position;
        //target += transform.forward * distance;




        Vector3 dir = (target - transform.position).normalized;
        Vector3 desiredVelocity = dir * Force;//


        Debug.DrawLine(transform.position, target, Color.cyan);


        steeringForce = desiredVelocity - rb.velocity;
        rb.AddForce( steeringForce) ;
        //rb.AddForce(steeringForce);
        //transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 head = rb.velocity;
        head.y = 0;
        transform.LookAt(transform.position + head, Vector3.up);
    }


    private void Update()
    {
        DoWander();
    }
}
