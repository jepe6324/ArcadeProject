using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerState
{
	public PlayerIdle()
	{
		stateID = "Idle";
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
		if (Input.GetButton(playerFSM.walkRightButton) || Input.GetButton(playerFSM.walkLeftButton))
		{
			StateExit(new PlayerWalk());
		}
	}
}

