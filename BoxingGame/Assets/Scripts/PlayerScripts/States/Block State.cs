using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : PlayerState
{
	float blockStun;
	float knockBackDistance;
	float knockBackFactor;

	float currentTime;
	float startPos;
	float endPos;

    public BlockState(PlayerStateMachine stateMachine, float blockStun, float knockBackDistance)
	{
		stateID = "Block";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
		this.blockStun = blockStun;
		this.knockBackDistance = knockBackDistance;

		currentTime = 0;
		startPos = playerFSM.transform.position.x;
		
		if (playerFSM.lookDirection == "Right")
		{
			endPos = - this.knockBackDistance;
		}
		else
		{
			endPos = this.knockBackDistance;
		}
	}

	public override void StateEnter()
	{
		playerAnimator.SetTrigger("Block");
		knockBackFactor = knockBackDistance / blockStun;
        AudioManager.PlayMusic("Block");
	}

	public override void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		float deltaTime = Time.deltaTime;
		currentTime += deltaTime;

		if (currentTime >= blockStun)
		{
			StateExit(new PlayerIdle(playerFSM));
			return;
		}

		float easingReturn = Easing(currentTime, startPos, endPos, blockStun);

		playerFSM.transform.position = new Vector2(easingReturn, playerFSM.transform.position.y);

		//if (playerFSM.lookDirection == "Right")
		//{
		//	playerFSM.transform.Translate(new Vector2(-knockBackFactor * deltaTime, 0)); // It would look cool to apply some form om easing to this.
		//}
		//else
		//{
		//	playerFSM.transform.Translate(new Vector2(knockBackFactor * deltaTime, 0));
		//}
	}

	// SOURCE: https://github.com/jesusgollonet/ofpennereasing/blob/master/PennerEasing
	float Easing(float currentTime, float startPos, float totalDistance, float endTime)
	{
		//if ((currentTime /= endTime / 2) < 1) return -totalDistance / 2 * (Mathf.Sqrt(1 - currentTime * currentTime) - 1) + startPos;
		//return totalDistance / 2 * (Mathf.Sqrt(1 - currentTime * (currentTime -= 2)) + 1) + startPos;
		//return totalDistance * ((currentTime = currentTime / endTime - 1) * currentTime * currentTime * currentTime * currentTime + 1) + startPos;
		return totalDistance * Mathf.Sqrt(1 - (currentTime = currentTime / endTime - 1) * currentTime) + startPos;
	}
}
