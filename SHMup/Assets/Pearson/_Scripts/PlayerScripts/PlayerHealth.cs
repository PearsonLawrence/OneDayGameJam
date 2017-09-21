﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour , Idamageable
{
    public float MaxHealth;
    float health;
	// Use this for initialization
	void Start () {
        health = MaxHealth;
	}
	
    public void TakeDamage(float DamageTaken)
    {
        health -= DamageTaken;
    }
    public bool alive;
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            alive = false;
        }

	}
}
