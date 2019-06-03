using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
	[HideInInspector] public PlayerState currentState;
	[HideInInspector] public string lookDirection;
	[HideInInspector] public bool acceptInput;

	public FloatReference forwardWalkSpeed;
	public FloatReference backWalkSpeed;

	public FloatReference evadeDuration;
	public FloatReference evadeInvincibilityTime;
	public FloatReference evadeSwayBack;

	public PlayerStateMachine otherPlayerFSM;
	private SpriteRenderer spriteRenderer;

	private CameraController cameraController;

	private Health health;

    // Start is called before the first frame update
    void Start()
	{
		if (name == "Player 1")
		{
			SetCharacter(CharacterSelector.player1Character);
		}
		else
		{
			SetCharacter(CharacterSelector.player2Character);
		}
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();

		currentState = new IntroState(this);
		currentState.StateEnter();

		cameraController = FindObjectOfType<CameraController>();
		health = GetComponent<Health>();
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
		return cameraController.ClampPlayerPosition(transform.position.x);
	}

	private void GetHit(PunchScriptableObject punch)
	{
		spriteRenderer.sortingOrder = 0;
		if (currentState.stateID == "Evade")
		{
			currentState.StateExit(new SwayBackState(this));
			return;
		}
		if ((currentState.stateID == "BackWalk" || currentState.stateID == "Block") && punch.punchID != "Uppercut")
		{
			currentState.StateExit(new BlockState(this, this.punch.blockStun, this.punch.knockbackDistance));
		}
		else // This is for when the player actually get's hit
		{
			BroadcastMessage("ReduceHealth", punch.damage);

			if (health.currentHealth <= 0)
			{
				currentState.StateExit(new KOState(this, punch));
			}
			else
			{
				currentState.StateExit(new HitState(this, this.punch.hitStun, this.punch.knockbackDistance));
			}
			FindObjectOfType<CameraController>().BroadcastMessage("CameraShaker", 0.2);
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
		if (other.tag != "Hitbox" && other.tag != "Whiff")
		{
			PushPlayersApart(other);
		}
	}

	public void Reset()
	{
		currentState = new IntroState(this);
		currentState.StateEnter();
	}

	public void SetCharacter(string characterName)
	{
		this.characterName = characterName;
		switch (characterName)
		{
			case "Angelov":
				characterGender = "Male";
				Instantiate(angelov, this.transform, false);
				break;
			case "Ragnar":
				characterGender = "Male";
				Instantiate(ragnar, this.transform, false);
				break;
			case "Pixel":
				characterGender = "Female";
				Instantiate(pixel, this.transform, false);
				break;
			case "Ikkx":
				characterGender = "Female";
				Instantiate(ikkx, this.transform, false);
				break;
			default:
				break;
		}
		if (name == "Player 2")
		{
			GetComponentInChildren<SpriteRenderer>().flipX = true;
		}
	}

	#region Punches
	public GameObject hitboxPrefab;

	public PunchScriptableObject punch;
	public PunchScriptableObject uppercut;
	#endregion // Punches

	#region Input
	public string walkRightButton;
	public string walkLeftButton;
	public string evadeButton;
	public string punchButton;
	public string uppercutButton;
	public string blockButton;
	#endregion //Input

	#region Character
	[HideInInspector] public string characterName;
	[HideInInspector] public string characterGender;

	public GameObject angelov;
	public GameObject pixel;
	public GameObject ragnar;
	public GameObject ikkx;
	#endregion //Character
}
