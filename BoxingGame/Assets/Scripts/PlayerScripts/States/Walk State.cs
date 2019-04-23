using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerState
{
	public PlayerWalk()
	{
		stateID = "Walk";
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
		if (Input.GetButton(playerFSM.walkRightButton))
		{
			if (playerFSM.lookDirection == "Right")
			{
				playerFSM.transform.Translate(new Vector2(playerFSM.forwardWalkSpeed.value * Time.deltaTime, 0));
			}
			else
			{
				playerFSM.transform.Translate(new Vector2(playerFSM.backWalkSpeed.value * Time.deltaTime, 0));
			}
		}

		else if (Input.GetButton(playerFSM.walkLeftButton))
		{
			if (playerFSM.lookDirection == "Left")
			{
				playerFSM.transform.Translate(new Vector2(-playerFSM.forwardWalkSpeed.value * Time.deltaTime, 0));
			}
			else
			{
				playerFSM.transform.Translate(new Vector2(-playerFSM.backWalkSpeed.value * Time.deltaTime, 0));
			}
		}
		else
			StateExit(new PlayerIdle());
	}
}
