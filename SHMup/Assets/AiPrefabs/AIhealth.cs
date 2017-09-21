using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIhealth : MonoBehaviour, Ikillable, Idamageable {

    public float health;
    private float MaxHealth;

	// Use this for initialization
	void Start () {
        MaxHealth = health;
	}
    public ParticleSystem Death;

    public void Die()
    {
        if(health <= 0)
        {
            ParticleSystem DeathPS = Instantiate(Death,transform.position,transform.rotation);
            Destroy(DeathPS, 4);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        Die();
    }


	// Update is called once per frame
	void Update () {
		
	}
}
