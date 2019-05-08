using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState : PlayerState
{
	public IntroState(PlayerStateMachine stateMachine)
	{
		stateID = "Intro";
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
		// Play the entire intro animation before going into the default state.
		StateExit(new DefaultState(playerFSM));
	}
}
