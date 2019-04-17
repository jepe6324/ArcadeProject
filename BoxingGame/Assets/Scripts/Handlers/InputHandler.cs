using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputHandler : MonoBehaviour, IGameplayActions
{
	public PlayerControls playerControls;
	private InputAction movement;
	private InputAction punch;

	[HideInInspector] public bool punchButton = false;
	[HideInInspector] public Vector2 direction;


	#region Player1

	public void OnMovement(InputAction.CallbackContext context)
	{
		direction = context.ReadValue<Vector2>();
	}
	public void OnPunches(InputAction.CallbackContext context)
	{
		punchButton = context.performed;
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
	#endregion Player1
}
