using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    Vector3 Cforce = Vector3.zero;
    Vector3 Aforce = Vector3.zero;
    Vector3 Sforce = Vector3.zero;
    
    public float radius;
   
    public float Force;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void flocking()
    {

        Vector3 Ctarget = Vector3.zero;
        Vector3 aDesire = Vector3.zero;
        Vector3 sSum = Vector3.zero;

        int hood = 0;
        Collider[] Hood = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider T in Hood)
        {

            if (T.GetComponent<Rigidbody>() == true)
            {
                hood++;
                Rigidbody rb = T.GetComponent<Rigidbody>();
                Ctarget += T.transform.position;
                aDesire += rb.velocity;
                sSum += (transform.position - T.transform.position) / radius;// * (radius - Vector3.Distance(transform.position, T.transform.position)) / radius;
            }

        }
        Ctarget /= hood;
        aDesire /= hood;
        sSum /= hood;



        Cforce = (Ctarget - transform.position).normalized * Force - rb.velocity;//
        Sforce = sSum.normalized * Force - rb.velocity;//
        Aforce = aDesire.normalized * Force - rb.velocity;//

        rb.AddForce(Cforce + Sforce + Aforce) ;
        Vector3 head = rb.velocity;
        head.y = 0;
        transform.LookAt(transform.position + head, Vector3.up);
    }


    // Update is called once per frame
    void Update()
    {
        flocking();
    }
}
