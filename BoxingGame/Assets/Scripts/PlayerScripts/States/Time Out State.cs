using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutState : PlayerState
{
	public TimeOutState(PlayerStateMachine stateMachine)
	{
		stateID = "TimeOut";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	public override void StateEnter()
	{
		playerAnimator.Play("TimeOut");
		playerAnimator.SetBool("Time Out", true);
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		if (playerAnimator.GetBool("Time Out"))
		{
			StateExit(new DefaultState(playerFSM));
		}
	}
}
