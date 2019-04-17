using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;

public class PlayerMovement: MonoBehaviour
{
	public InputHandler inputHandler;

	public FloatReference backWalkSpeed;
	public FloatReference forwardWalkSpeed;

	private SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
    {
		if (inputHandler.direction.x > 0)
			MoveRight();
		else if (inputHandler.direction.x < 0)
			MoveLeft();

		if (inputHandler.punchButton == true)
		{
			TurnAround();
			inputHandler.punchButton = false; // I am doing this to make it only register the button press, and not the entire duration the button is held
			// Ugly af but the best I have at the moment
		}
	}

	void MoveRight()
	{
		if (spriteRenderer.flipX == false) // AKA character is facing right
		{ 
			transform.Translate(new Vector2(forwardWalkSpeed.value * Time.deltaTime, 0));
		}
		else
		{
			transform.Translate(new Vector2(backWalkSpeed.value * Time.deltaTime, 0));
		}
	}
	void MoveLeft()
	{
		if (spriteRenderer.flipX == true) // AKA character is facing left
		{
			transform.Translate(new Vector2(-forwardWalkSpeed.value * Time.deltaTime, 0));
		}
		else
		{
			transform.Translate(new Vector2(-backWalkSpeed.value * Time.deltaTime, 0));
		}
	}

	void TurnAround()
	{

		if (spriteRenderer.flipX == false)
		{
			spriteRenderer.flipX = true;
		}
		else
		{
			spriteRenderer.flipX = false;
		}
	}
}
