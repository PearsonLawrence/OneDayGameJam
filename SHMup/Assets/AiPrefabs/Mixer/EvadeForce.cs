using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeForce : MonoBehaviour {
    [HideInInspector]
    public GameObject Predator;
    [HideInInspector]
    public float Force;
    private Vector3 velocity;
    Rigidbody rb;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	

    public Vector3 DoEvade()
    {
        Vector3 target = Predator.transform.position + Predator.GetComponent<Rigidbody>().velocity;
        Vector3 dir = -(target - transform.position).normalized;
        Vector3 desiredVelocity = dir;
        Vector3 steeringForce = desiredVelocity - rb.velocity;




        return (steeringForce.normalized * 2 )  * Force;


        
    }

	// Update is called once per frame
	void Update ()
    {

        DoEvade();
        

    }
}
