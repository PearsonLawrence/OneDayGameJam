using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamage : MonoBehaviour {

    public float Damage;


	// Use this for initialization
	void Start () {
		
	}
    public ParticleSystem death;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ParticleSystem deathPS = Instantiate(death, transform.position, transform.rotation);
            Destroy(deathPS, 5);
            collision.gameObject.GetComponent<Idamageable>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
