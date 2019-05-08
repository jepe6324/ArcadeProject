using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	float duration;

	PunchScriptableObject punch;

	public void SetVariables(PunchScriptableObject punch, string direction)
	{
		BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
		myCollider.size = new Vector2(punch.sizeX, punch.sizeY);
		if (direction == "Right")
		{
			myCollider.offset = new Vector2(punch.posX, punch.posY);
		}
		else
		{
			myCollider.offset = new Vector2(-punch.posX, punch.posY);
		}
		this.duration = punch.activeTime;
		this.punch = punch;
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
		if (other.CompareTag(GetComponentInParent<PlayerStateMachine>().tag) == false && other.tag != tag)
			other.BroadcastMessage("GetHit", punch); // send data about what attack just hit the player.
	}
}
