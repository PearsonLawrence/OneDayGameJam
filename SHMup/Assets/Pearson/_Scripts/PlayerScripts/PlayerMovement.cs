using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody RB;
    private Transform MTrans;

    public float Setspeed;
    private float speed;

    private Vector3 movement;

   
	void Start () {
        
        if(GetComponent<Rigidbody>() != null)
        {
            RB = GetComponent<Rigidbody>();
        }
        MTrans = GetComponent<Transform>();
        speed = Setspeed;
	}
	

    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Verticle = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, 0, Verticle);

        RB.velocity = (movement * speed);
    }
    Vector3 MousePos;

    void RotatePlayer()
    {
        float horizontal = Input.GetAxisRaw("Xaxis");
        float vertical = Input.GetAxisRaw("Yaxis");

        Vector3 desiredRot = new Vector3(MTrans.position.x + horizontal, MTrans.position.y,  MTrans.position.z + vertical);

        MTrans.forward = Vector3.Slerp(MTrans.forward,-(MTrans.position - desiredRot).normalized,.2f);

    }


	void FixedUpdate ()
    {
        MovePlayer();
        RotatePlayer();
	}



}
