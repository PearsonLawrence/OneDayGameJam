using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathlessSeeking : MonoBehaviour {

    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public float Force;
    Vector3 velocity;
    Rigidbody rb;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	

    public Vector3 DoSeek()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Vector3 desiredVelocity = dir ; //


        Vector3 steeringForce = desiredVelocity - rb.velocity;
        return steeringForce * Force;
       
    }

	// Update is called once per frame
	void Update ()
    {
        DoSeek();
	}
}
