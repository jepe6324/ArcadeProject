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
