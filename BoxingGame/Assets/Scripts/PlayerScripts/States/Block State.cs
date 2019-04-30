using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : PlayerState
{
	float blockStun;
	float knockBackDistance;
	float knockBackFactor;

    public BlockState(PlayerStateMachine stateMachine, float blockStun, float knockBackDistance)
	{
		stateID = "Block";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
		this.blockStun = blockStun;
		this.knockBackDistance = knockBackDistance / 4;
	}

	public override void StateEnter()
	{
		playerAnimator.SetTrigger("Block");
		knockBackFactor = knockBackDistance / blockStun;
        AudioManager.PlayMusic("dodge");
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		float deltaTime = Time.deltaTime;
		blockStun -= deltaTime;

		if (blockStun <= 0)
		{
			StateExit(new PlayerIdle(playerFSM));
			return;
		}

		if (playerFSM.lookDirection == "Right")
		{
			playerFSM.transform.Translate(new Vector2(-knockBackFactor * deltaTime, 0)); // It would look cool to apply some form om easing to this.
		}
		else
		{
			playerFSM.transform.Translate(new Vector2(knockBackFactor * deltaTime, 0));
		}
	}
}
