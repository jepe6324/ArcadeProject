using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : PlayerState
{
	float hitStun;
	float knockBackDistance;
	float knockBackFactor;

	float currentTime;
	float startPos;
	float endPos;

	public HitState(PlayerStateMachine stateMachine, float hitStun, float knockBackDistance)
	{
		stateID = "Hit";
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();
		this.hitStun = hitStun;
		this.knockBackDistance = knockBackDistance;

		currentTime = 0;
		startPos = playerFSM.transform.position.x;

		if (playerFSM.lookDirection == "Right")
		{
			endPos = -this.knockBackDistance;
		}
		else
		{
			endPos = this.knockBackDistance;
		}
	}

	public override void StateEnter()
	{
		playerAnimator.SetTrigger("Hit");
		knockBackFactor = knockBackDistance / hitStun;
        AudioManager.PlayMusic(playerFSM.characterName + "Punch");
	}

	public override void StateExit(PlayerState nextState)
	{
		SetToWhite();
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	public override void StateUpdate()
	{
		HitFlash();
		float deltaTime = Time.deltaTime;
		currentTime += deltaTime;

		float easingReturn = Easing(currentTime, startPos, endPos, hitStun);

		playerFSM.transform.position = new Vector2(easingReturn, playerFSM.transform.position.y);

		//if (playerFSM.lookDirection == "Right")
		//{
		//	playerFSM.transform.Translate(new Vector2(-knockBackFactor * deltaTime, 0)); // It would look cool to apply some form om easing to this.
		//}
		//else
		//{
		//	playerFSM.transform.Translate(new Vector2(knockBackFactor * deltaTime, 0));
		//}

		if (currentTime >= hitStun)
		{
			StateExit(new PlayerIdle(playerFSM));
		}
	}

	public void HitFlash()
	{
		SpriteRenderer spriteRenderer = playerFSM.GetComponentInChildren<SpriteRenderer>();

		Color randColor = new Color();
		randColor.r = 1;
		randColor.g = Random.value;
		randColor.b = Random.value;
		randColor.a = 1;

		if (spriteRenderer.color == Color.white)
			spriteRenderer.color = randColor;
		else
			spriteRenderer.color = Color.white;
	}

	public void SetToWhite()
	{
		playerFSM.GetComponentInChildren<SpriteRenderer>().color = Color.white;
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
