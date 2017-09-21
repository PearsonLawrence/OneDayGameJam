using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMixer : MonoBehaviour {

    private GameObject Prey;
    Flocking flock;
    EvadeForce evade;
    Wander wander;
    PathlessSeeking seek;
    Rigidbody rb;
    public float speed;
    public float initFlockForce;
    public float initEvadeForce;
    public float initWanderForce;
    public float initSeekForce;

    public float initFlockRadius;
    public float initWanderRadius;
    public float initWanderJitter;
    public float initWanderDistance;

    public float flockForce
    {
        set
        {
            flock.Force = value;
        }
        get
        {
            return flock.Force;
        }
    }
    public float evadeForce
    {
        set
        {
            evade.Force = value;
        }
        get
        {
            return evade.Force;
        }
    }
    public float wanderForce
    {
        set
        {
            wander.Force = value;
        }
        get
        {
            return wander.Force;
        }
    }
    public float seekForce
    {
        set
        {
            seek.Force = value;
        }
        get
        {
            return seek.Force;
        }
    }

    public GameObject evadeTarget
    {
        set
        {
            evade.Predator = value;
        }
        get
        {
            return evade.Predator;
        }
    }
    public GameObject seekTarget
    {
        set
        {
            seek.target = value;
        }
        get
        {
            return seek.target;
        }
    }

    public float flockRadius
    {
        set
        {
            flock.radius = value;
        }
        get
        {
            return flock.radius;
        }
    }
    public float wanderRadius
    {
        set
        {
            wander.radius = value;
        }
        get
        {
            return wander.radius;
        }
    }
    public float wanderJitter
    {
        set
        {
            wander.jitter = value;
        }
        get
        {
            return wander.jitter;
        }
    }
    public float wanderDistance
    {
        set
        {
            wander.distance = value;
        }
        get
        {
            return wander.distance;
        }
    }


    // Use this for initialization
    void Start()
    {
        Prey = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        flock = GetComponent<Flocking>();
        evade = GetComponent<EvadeForce>();
        wander = GetComponent<Wander>();
        seek = GetComponent<PathlessSeeking>();
        flockForce = initFlockForce;
        evadeForce = initEvadeForce;
        wanderForce = initWanderForce;
        seekForce = initSeekForce;

        evadeTarget = Prey;
        seekTarget = Prey;

        flockRadius = initFlockRadius;
        wanderRadius = initWanderRadius;
        wanderJitter = initWanderJitter;
        wanderDistance = initWanderDistance;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ForceToBeApplied = flock.flocking() + evade.DoEvade() + wander.DoWander() + seek.DoSeek();

        ForceToBeApplied.Normalize();

        Vector3 Vflock = flock.flocking();
        Vector3 Vevade = evade.DoEvade();
        Vector3 Vseek = seek.DoSeek();

        Vector3 Vwander = wander.DoWander();

        //Debug.Log("FLOCK");
        //Debug.Log(Vflock.ToString());
        //Debug.Log("EVADE");
        //Debug.Log(Vevade.ToString());
        //Debug.Log("SEEK");
        //Debug.Log(Vseek.ToString());
        //Debug.Log("WANDER");
        //Debug.Log(Vwander.ToString());
        Debug.Log(ForceToBeApplied );
        Debug.Log(ForceToBeApplied * speed);
        rb.AddForce(ForceToBeApplied * speed);

        //ForceToBeApplied.x = Mathf.Clamp(ForceToBeApplied.x, -5, 5);
        //ForceToBeApplied.y = Mathf.Clamp(ForceToBeApplied.y, -5, 5);
        //ForceToBeApplied.z = Mathf.Clamp(ForceToBeApplied.z, -5, 5);

        //rb.velocity = ForceToBeApplied * speed;

       

        Vector3 head = rb.velocity;
        head.y = 0;
        transform.LookAt(transform.position + head, Vector3.up);
    }
}
