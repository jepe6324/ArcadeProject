using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	[HideInInspector] public float duration;
	[HideInInspector] public string ID;

	public void SetVariables(float duration, float sizeX, float sizeY, float posX, float posY, string ID = "null")
	{
		BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
		myCollider.size = new Vector2(sizeX, sizeY);
		myCollider.offset = new Vector2(posX, posY);
		this.duration = duration;
		this.ID = ID;
	}

	void Update()
	{
		duration -= Time.deltaTime;
		if (duration < 0)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
	}
}
