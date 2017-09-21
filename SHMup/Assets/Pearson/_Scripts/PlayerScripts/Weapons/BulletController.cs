using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    Rigidbody RB;
    public float speed;
    public float lifetime;
    public float damageAmount;
	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;

        RB.velocity = (transform.forward * speed);
        Destroy(gameObject,lifetime);
        
	}

    public ParticleSystem ps;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (other.GetComponent<Idamageable>() != null)
            {
                other.GetComponent<Idamageable>().TakeDamage(damageAmount);
            }
        }
        if (!other.CompareTag("bullet") && !other.CompareTag("Player"))
        {
            ParticleSystem p = Instantiate(ps, transform.position, transform.rotation);
            Destroy(p, 3);
            Destroy(gameObject);
        }
    }
}
