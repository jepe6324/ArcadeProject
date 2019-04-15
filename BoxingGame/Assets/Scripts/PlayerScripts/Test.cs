using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

enum Player_State
{
	IDLE,
	FORWARD_WALK,
	BACK_WALK,
	ATTACK,
	HIT_STUN,
	BLOCK_STUN,
	INTRO,
	OUTRO
}

public class Test : MonoBehaviour, IGameplayActions
{
	public PlayerControls playerControls;
	private InputAction movement;
	private InputAction punch;

	public FloatReference forwardWalkSpeed;
	public FloatReference backWalkSpeed;

	Player_State current_state = Player_State.INTRO;

	void Update()
	{
		switch (current_state) // Deduce wich state the player is currently in and run it.
		{
			case Player_State.INTRO:
				// Intro.Update(); Or something
				break;
			default:
				break;
		}
	}

	public void OnMovement(InputAction.CallbackContext context)
	{
		direction = context.ReadValue<Vector2>();
	}
	public void OnPunches(InputAction.CallbackContext context)
	{
	}

	private void Awake()
	{
		playerControls.Gameplay.SetCallbacks(this);
	}

	private void OnEnable()
	{
		playerControls.Enable();
	}
	private void OnDisable()
	{
		playerControls.Disable();
	}

	private Vector2 direction;
}
