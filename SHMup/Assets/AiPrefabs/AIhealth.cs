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
	

    public void Die()
    {
        if(health <= 0)
        {
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
