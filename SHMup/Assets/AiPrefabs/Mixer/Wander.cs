using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {


    private Vector3 target;
    [HideInInspector]
    public float radius;
    [HideInInspector]
    public float jitter;
    [HideInInspector]
    public float distance;
    private Vector3 steeringForce;
    Rigidbody rb;
    [HideInInspector]
    public float Force;
    


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    public Vector3 DoWander()
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
        Vector3 desiredVelocity = dir ;//


        Debug.DrawLine(transform.position, target, Color.cyan);


        steeringForce = desiredVelocity - rb.velocity;
        return steeringForce * Force;
        //rb.AddForce(steeringForce);
        //transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);

    }


    private void Update()
    {
        DoWander();
    }
}
