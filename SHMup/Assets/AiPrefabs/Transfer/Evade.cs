using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : MonoBehaviour {

   
    private GameObject Predator;
    
    public float Force;
    private Vector3 velocity;
    Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        Predator = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }


    public void DoEvade()
    {
        Vector3 target = Predator.transform.position + Predator.GetComponent<Rigidbody>().velocity;
        Vector3 dir = -(target - transform.position).normalized;
        Vector3 desiredVelocity = dir * Force;
        Vector3 steeringForce = desiredVelocity - rb.velocity;




        rb.AddForce(steeringForce.normalized * 2) ;


        Vector3 head = rb.velocity;
        head.y = 0;
        transform.LookAt(transform.position + head, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {

        DoEvade();


    }
}
