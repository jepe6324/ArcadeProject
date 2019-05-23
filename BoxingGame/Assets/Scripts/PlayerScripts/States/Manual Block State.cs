using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualBlockState : PlayerState
{
	public ManualBlockState(PlayerStateMachine stateMachine)
	{
		stateID = "Block"; // Has the same ID as block because to everything else it is supposed to just be block.
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	public override void StateEnter()
	{
		playerAnimator.SetTrigger("Block");
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
		playerAnimator.ResetTrigger("Block");
	}

	public override void StateUpdate()
	{
		if (!Input.GetButton(playerFSM.blockButton))
		{
			StateExit(new PlayerIdle(playerFSM));
		}
	}
}
