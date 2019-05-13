using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroState : PlayerState
{
	public OutroState(PlayerStateMachine stateMachine)
	{
		stateID = "Outro";
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
		// Play an entire outro animation before going into the default state.
		StateExit(new DefaultState(playerFSM));
	}
}