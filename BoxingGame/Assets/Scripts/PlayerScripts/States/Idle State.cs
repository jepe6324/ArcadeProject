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
		playerAnimator.SetTrigger("Idle");
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
		playerAnimator.ResetTrigger("Idle");
	}

	public override void StateUpdate()
	{
		playerFSM.UpdateLookDirection();

		if (playerFSM.acceptInput == true)
		{
			if (Input.GetButton(playerFSM.blockButton))
			{
				StateExit(new ManualBlockState(playerFSM));
				return;
			}

			if (Input.GetButtonDown(playerFSM.evadeButton))
			{
				StateExit(new EvadeState(playerFSM));
				return;
			}
			else if (Input.GetButtonDown(playerFSM.punchButton))
			{
				StateExit(new PlayerPunch(playerFSM, playerFSM.punch));
				return;
			}
			else if (Input.GetButtonDown(playerFSM.uppercutButton))
			{
				StateExit(new PlayerPunch(playerFSM, playerFSM.uppercut));
				return;
			}

			if (Input.GetButton(playerFSM.walkRightButton) && Input.GetButton(playerFSM.walkLeftButton))
			{

			}
			else if (Input.GetButton(playerFSM.walkRightButton) || Input.GetButton(playerFSM.walkLeftButton))
			{
				StateExit(new PlayerWalk(playerFSM));
				return;
			}
		}
	}
}

