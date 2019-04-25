using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	float duration;
	string ID;

	Vector3 variables;

	public void SetVariables(float duration, float sizeX, float sizeY, float posX, float posY, float hitStun, float blockStun, float knockBackDistance, string ID = "null")
	{
		BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
		myCollider.size = new Vector2(sizeX, sizeY);
		myCollider.offset = new Vector2(posX, posY);
		this.duration = duration;
		this.ID = ID;

		variables = new Vector3(hitStun, blockStun, knockBackDistance); // I am just making a vector3 contain those floats
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
