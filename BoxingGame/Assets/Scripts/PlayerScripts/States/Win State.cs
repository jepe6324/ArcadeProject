using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : PlayerState
{
	public WinState(PlayerStateMachine stateMachine)
	{
		stateID = "Win";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	public override void StateEnter()
	{
		playerAnimator.SetBool("Win", true);
		playerAnimator.Play("Win");
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		if (playerAnimator.GetBool("Win") == false)
		{
			StateExit(new DefaultState(playerFSM));
		}
	}
}
