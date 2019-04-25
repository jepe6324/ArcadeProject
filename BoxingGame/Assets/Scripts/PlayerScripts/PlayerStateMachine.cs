using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
	[HideInInspector] public PlayerState currentState;
	[HideInInspector] public string lookDirection;

	public FloatReference forwardWalkSpeed;
	public FloatReference backWalkSpeed;

	public PlayerStateMachine otherPlayerFSM;
	private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
		currentState = new PlayerIdle(this);
		currentState.StateEnter();

		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		currentState.StateUpdate();
		transform.position = new Vector3(ClampPosition(), transform.position.y, 0);
    }

	public void UpdateLookDirection()
	{
		float distance = transform.position.x - otherPlayerFSM.transform.position.x;

		if (distance > 0)
		{
			lookDirection = "Left";
			spriteRenderer.flipX = true;
		}
		else
		{
			lookDirection = "Right";
			spriteRenderer.flipX = false;
		}
	}

	private float ClampPosition()
	{
		float x = transform.position.x;
		float a = -8.4f;
		float b = -a;

		// Is x smaller than a? If it is set x to a. Otherwise see if x is bigger than b, if it is set it to b. Otherwise x remains x.
		return x = (x < a) ? a : ((x > b) ? b : x); 
	}

	private void GetHit(Vector3 variables)
	{
		if (currentState.stateID == "BackWalk" || currentState.stateID == "Block")
		{
			currentState.StateExit(new BlockState(this, variables.y, variables.z));
		}
		else
		{
			currentState.StateExit(new HitState(this, variables.x, variables.z));
		}
	}

	private void PushPlayersApart(Collider2D other)
	{
		Collider2D myCollider = GetComponent<Collider2D>();
		float distance = Mathf.Abs(this.transform.position.x - other.transform.position.x);
		float overlap = myCollider.bounds.extents.x + other.bounds.extents.x - distance;
		if (lookDirection == "Left") // If this is true this player is on the right side
		{
			this.transform.Translate(new Vector2(overlap / 2.0f, 0));
			other.transform.Translate(new Vector2(-overlap / 2.0f, 0));
		}
		else
		{
			this.transform.Translate(new Vector2(-overlap / 2.0f, 0));
			other.transform.Translate(new Vector2(overlap / 2.0f, 0));
		}
		Debug.Log(name + " " + overlap);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Hitbox")
		{
			if (other.GetComponentInParent<PlayerStateMachine>().CompareTag(this.tag))
			{
				return;
			}
			//GetHit();
		}
		else
		{
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag != "Hitbox")
		{
			PushPlayersApart(other);
		}
	}

	#region Punches
	public GameObject hitboxPrefab;

	public PunchScriptableObject straightPunch;
	public PunchScriptableObject uppercut;
	#endregion // Punches

	#region Input
	public string walkRightButton;
	public string walkLeftButton;
	public string punchButton;
	#endregion //Input
}
