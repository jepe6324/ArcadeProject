using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOState : PlayerState
{
	float knockBack;
	public KOState(PlayerStateMachine stateMachine, PunchScriptableObject punch)
	{
		stateID = "KO";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
		knockBack = punch.knockbackDistance * 2;
	}

	public override void StateEnter()
	{
		playerAnimator.SetBool("KO", true);
		playerAnimator.Play("KO");
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		float deltaTime = Time.deltaTime;

		if (playerFSM.lookDirection == "Right")
		{
			playerFSM.transform.Translate(new Vector2(-knockBack * deltaTime, 0)); // It would look cool to apply some form om easing to this.
		}
		else
		{
			playerFSM.transform.Translate(new Vector2(knockBack * deltaTime, 0));
		}
		
		if ((knockBack -= deltaTime) < 0)
		{
			knockBack = 0;
		}
		if (playerAnimator.GetBool("KO") == false)
		{
			StateExit(new DefaultState(playerFSM));
		}
	}
}