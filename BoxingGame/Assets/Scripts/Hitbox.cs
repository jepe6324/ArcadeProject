using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	float duration;

	Variables variables;

	public void SetVariables(float duration, float sizeX, float sizeY, float posX, float posY, float hitStun, float blockStun, float knockBackDistance)
	{
		BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
		myCollider.size = new Vector2(sizeX, sizeY);
		myCollider.offset = new Vector2(posX, posY);
		this.duration = duration;

		variables = new Variables(hitStun, blockStun, knockBackDistance, name); // I am just making a vector3 contain those floats
	}

	void Start()
	{
	}

	void Update()
	{
		duration -= Time.deltaTime;
		if (duration < 0)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(GetComponentInParent<PlayerStateMachine>().tag) == false)
			other.BroadcastMessage("GetHit", variables); // send data about what attack just hit the player.
	}
}

public class Variables
{
	public Variables(float hitStun, float blockStun, float knockbackDistance, string ID)
	{
		this.hitStun = hitStun;
		this.blockStun = blockStun;
		this.knockbackDistance = knockbackDistance;
		this.ID = ID;
	}

	public float hitStun;
	public float blockStun;
	public float knockbackDistance;
	public string ID;
}
