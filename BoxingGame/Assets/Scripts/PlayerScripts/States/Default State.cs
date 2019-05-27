using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : PlayerState
{
	public DefaultState(PlayerStateMachine stateMachine)
	{
		stateID = "Default";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	public override void StateEnter()
	{
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{

	}
}
