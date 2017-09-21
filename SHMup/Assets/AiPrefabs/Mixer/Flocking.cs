using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour {


    Vector3 Cforce = Vector3.zero;
    Vector3 Aforce = Vector3.zero;
    Vector3 Sforce = Vector3.zero;
    [HideInInspector]
    public float radius;
    [HideInInspector]
    public float Force;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	


    public Vector3 flocking()
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



        Cforce = (Ctarget - transform.position).normalized  - rb.velocity;//
        Sforce = sSum.normalized  - rb.velocity;//
        Aforce = aDesire.normalized  - rb.velocity;//

        return (Cforce + Sforce + Aforce) * Force;

    }


	// Update is called once per frame
	void Update () {
		
	}
}
