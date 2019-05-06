using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerState
{
	public PlayerWalk(PlayerStateMachine stateMachine)
	{
		stateID = "Walk";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	override public void StateEnter()
	{
		playerAnimator.SetBool("Forward Walk", true);
	}

	public override void StateExit(PlayerState nextState)
	{
		playerAnimator.SetBool("Forward Walk", false);


		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		playerFSM.UpdateLookDirection();

		if (Input.GetButtonDown(playerFSM.evadeButton))
		{
			StateExit(new EvadeState(playerFSM));
		}

		if (Input.GetButtonDown(playerFSM.punchButton))
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
			StateExit(new PlayerIdle(playerFSM));
		}
		else if (Input.GetButton(playerFSM.walkRightButton))
		{
			if (playerFSM.lookDirection == "Right")
			{
				playerFSM.transform.Translate(new Vector2(playerFSM.forwardWalkSpeed.value * Time.deltaTime, 0));
				stateID = "ForwardWalk";
			}
			else
			{
				playerFSM.transform.Translate(new Vector2(playerFSM.backWalkSpeed.value * Time.deltaTime, 0));
				stateID = "BackWalk";
			}
		}
		else if (Input.GetButton(playerFSM.walkLeftButton))
		{
			if (playerFSM.lookDirection == "Left")
			{
				playerFSM.transform.Translate(new Vector2(-playerFSM.forwardWalkSpeed.value * Time.deltaTime, 0));
				stateID = "ForwardWalk";
			}
			else
			{
				playerFSM.transform.Translate(new Vector2(-playerFSM.backWalkSpeed.value * Time.deltaTime, 0));
				stateID = "BackWalk";
			}
		}
		else
			StateExit(new PlayerIdle(playerFSM));
	}
}
