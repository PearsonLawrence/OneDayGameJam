using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerMovement[] Players; 

    private GameObject[] PlayerBodies;

    public float SetSpeed;
    private float speed;

    private float offset;

    float dt;
	// Use this for initialization
	void Start () {
        PlayerBodies = GameObject.FindGameObjectsWithTag("Player"); 
        
      
        speed = SetSpeed;
        offset = transform.position.y;
	}
	
    void CameraFollow()
    {
        Vector3 desiredPos = new Vector3(PlayerBodies[0].transform.position.x, offset, PlayerBodies[0].transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPos, dt * speed);
    }
    // Update is called once per frame
    void LateUpdate ()
    {
        dt = Time.deltaTime;
        CameraFollow();
	}
}
