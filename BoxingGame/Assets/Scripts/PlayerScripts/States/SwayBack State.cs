using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayBackState : PlayerState
{
	float swaybackTime;
	public SwayBackState(PlayerStateMachine stateMachine)
	{
		stateID = "Default";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
	}

	public override void StateEnter()
	{
		swaybackTime = playerFSM.evadeSwayBack.value;
		AudioManager.PlayMusic(playerFSM.characterName + "Dodge");
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		swaybackTime -= Time.deltaTime;
		
		if (swaybackTime <= 0)
		{
			StateExit(new PlayerIdle(playerFSM));
		}
	}
}
