using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayBackState : PlayerState
{
	float swaybackTime;
	public SwayBackState(PlayerStateMachine stateMachine)
	{
		stateID = "Default";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	public override void StateEnter()
	{
		swaybackTime = playerFSM.evadeSwayBack.value;
		AudioManager.PlayMusic(playerFSM.characterName + "Dodge");
	}

	public override void StateExit(PlayerState nextState)
	{
		SetToWhite();
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		swaybackTime -= Time.deltaTime;

		HitFlash();

		if (swaybackTime <= 0)
		{
			StateExit(new PlayerIdle(playerFSM));
		}
	}

	public void HitFlash()
	{
		SpriteRenderer spriteRenderer = playerFSM.GetComponentInChildren<SpriteRenderer>();

		Color randColor = new Color();
		randColor.r = Random.Range(0, 1f);
		randColor.g = 1;
		randColor.b = 1;
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
