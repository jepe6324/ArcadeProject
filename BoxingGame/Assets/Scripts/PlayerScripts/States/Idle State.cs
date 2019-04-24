using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerState
{
	public PlayerIdle(PlayerStateMachine stateMachine)
	{
		stateID = "Idle";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	override public void StateEnter()
	{
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		playerFSM.UpdateLookDirection();

		if (Input.GetButton(playerFSM.walkRightButton) || Input.GetButton(playerFSM.walkLeftButton))
		{
			StateExit(new PlayerWalk(playerFSM));
		}
		else if (Input.GetButtonDown(playerFSM.punchButton))
		{
			StateExit(new PlayerPunch(playerFSM, playerFSM.straightPunch));
			return;
		}
	}
}

