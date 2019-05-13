using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : PlayerState
{
	float hitStun;
	float knockBackDistance;
	float knockBackFactor;

    public HitState(PlayerStateMachine stateMachine, float hitStun, float knockBackDistance)
	{
		stateID = "Hit";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
		this.hitStun = hitStun;
		this.knockBackDistance = knockBackDistance;
	}

	public override void StateEnter()
	{
		playerAnimator.SetTrigger("Hit");
		knockBackFactor = knockBackDistance / hitStun;
        AudioManager.PlayMusic("punch");
	}

	public override void StateExit(PlayerState nextState)
	{
		SetToWhite();
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		HitFlash();
		float deltaTime = Time.deltaTime;
		hitStun -= deltaTime;

		if (playerFSM.lookDirection == "Right")
		{
			playerFSM.transform.Translate(new Vector2(-knockBackFactor * deltaTime, 0)); // It would look cool to apply some form om easing to this.
		}
		else
		{
			playerFSM.transform.Translate(new Vector2(knockBackFactor * deltaTime, 0));
		}

		if (hitStun <= 0)
		{
			StateExit(new PlayerIdle(playerFSM));
		}
	}

	public void HitFlash()
	{
		SpriteRenderer spriteRenderer = playerFSM.GetComponentInChildren<SpriteRenderer>();

		Color randColor = new Color();
		randColor.r = 1;
		randColor.g = Random.value;
		randColor.b = Random.value;
		randColor.a = 1;

		if (spriteRenderer.color == Color.white)
			spriteRenderer.color = randColor;
		else
			spriteRenderer.color = Color.white;
	}

	public void SetToWhite()
	{
		playerFSM.GetComponentInChildren<SpriteRenderer>().color = Color.white;
	}
}
