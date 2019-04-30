using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState : PlayerState
{
	public float duration;
	public float invincibilityTime;

	public EvadeState(PlayerStateMachine stateMachine)
	{
		stateID = "Evade";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();

		duration = playerFSM.evadeDuration.value;
		invincibilityTime = playerFSM.evadeInvincibilityTime.value;
	}

	override public void StateEnter()
	{
		playerAnimator.SetTrigger("Evade");
	}

	override public void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	override public void StateUpdate()
	{
		duration -= Time.deltaTime;
		invincibilityTime -= Time.deltaTime;

		if (invincibilityTime <= 0 && stateID == "Evade")
		{
			stateID = "EvadeRecovery";
		}
		if (duration <= 0)
		{
			StateExit(new PlayerIdle(playerFSM));
			return;
		}
	}
}