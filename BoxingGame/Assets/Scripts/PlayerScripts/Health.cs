using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float maxHealth = 100.0f;
	public float currentHealth;

	void Start()
	{
		currentHealth = maxHealth;
	}
		

	public void ReduceHealth(int damage)
	{
		currentHealth -= damage;

		Debug.Log(currentHealth);
	}
		
   
	void Update ()
	{
		if (currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
}
