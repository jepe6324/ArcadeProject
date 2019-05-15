using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public FloatReference maxHealth;
	[HideInInspector] public float currentHealth;

	void Start()
	{
		currentHealth = maxHealth.value;
	}
		

	public void ReduceHealth(int damage)
	{
		currentHealth -= damage;
	}
		
   
	void Update ()
	{
		if (currentHealth <= 0)
		{
			// Do loose game sequence
		}
	}

	void ResetHealth()
	{
		currentHealth = maxHealth.value;
	}
}
