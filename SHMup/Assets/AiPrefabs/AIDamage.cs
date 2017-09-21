using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamage : MonoBehaviour {

    public float Damage;


	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Idamageable>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
