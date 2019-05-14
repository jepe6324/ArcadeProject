using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	float activeTime;
	float whiffTime;

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
		this.activeTime = punch.activeTime;
		this.punch = punch;

		this.whiffTime = punch.duration - punch.activeTime;
	}

	void Start()
	{
	}

	void Update()
	{
		if (tag == "Whiff")
		{
			whiffTime -= Time.deltaTime;
		}
		else
		{
			activeTime -= Time.deltaTime;
		}

		if (activeTime < 0)
			tag = "Whiff";
		if (whiffTime < 0)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (tag != "Whiff")
		{
			if (other.tag == "Whiff")
			{
				other.GetComponentInParent<PlayerStateMachine>().BroadcastMessage("GetHit", punch);
			}
			else if (other.CompareTag(GetComponentInParent<PlayerStateMachine>().tag) == false && other.tag != tag)
			{
				other.BroadcastMessage("GetHit", punch); // send data about what attack just hit the player.
			}

			transform.parent.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
		}
	}
}
