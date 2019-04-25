using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : PlayerState
{
	public float duration;
	public float startUpTime;

	public string punchID;

	public float damage;
	public float activeTime;
	public float sizeX;
	public float sizeY;
	public float posX;
	public float posY;

	public float knockBackDistance;
	public float hitStun;
	public float blockStun;

	private bool donePunch;

	public PlayerPunch(PlayerStateMachine stateMachine, PunchScriptableObject punch)
	{
		stateID = "Punch"; // This is a shitty prototype name since we will add more punches
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();

		duration = punch.duration;
		startUpTime = punch.startUpTime;
		punchID = punch.punchID;
		damage = punch.damage;
		activeTime = punch.activeTime;
		sizeX = punch.sizeX;
		sizeY = punch.sizeY;
		posX = punch.posX;
		posY = punch.posY;
		knockBackDistance = punch.knockBackDistance;
		hitStun = punch.hitStun;
		blockStun = punch.blockStun;
	}

	override public void StateEnter()
	{
		donePunch = false;
		playerAnimator.SetTrigger("Punch");
	}

	override public void StateExit(PlayerState nextState)
	{
		playerFSM.currentState = nextState;
		nextState.StateEnter();
	}

	override public void StateUpdate()
	{
		duration -= Time.deltaTime;
		startUpTime -= Time.deltaTime;

		if (duration <= 0)
		{
			StateExit(new PlayerIdle(playerFSM));
			playerAnimator.SetTrigger("Idle");
		}
		else if (startUpTime <= 0 && donePunch == false)
		{
			donePunch = true;
			GameObject clone = GameObject.Instantiate(playerFSM.hitboxPrefab, playerFSM.transform);
			if (playerFSM.lookDirection == "Right")
			{
				clone.GetComponent<Hitbox>().SetVariables(activeTime, sizeX, sizeY, posX, posY, hitStun, blockStun, knockBackDistance);
			}
			else // Left, if I knew more about ternary operators this would probably be prettier
			{
				clone.GetComponent<Hitbox>().SetVariables(activeTime, sizeX, sizeY, -posX, posY, hitStun, blockStun, knockBackDistance);
			}
		}
	}
}