using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : PlayerState
{
	public float duration;
	public float startUpTime;
	public string punchID;
	public float activeTime;

	private bool donePunch;

	private PunchScriptableObject punch;

	public PlayerPunch(PlayerStateMachine stateMachine, PunchScriptableObject punch)
	{
		stateID = "Punch"; // This is a shitty prototype name since we will add more punches
		playerFSM = stateMachine;
		playerAnimator = stateMachine.GetComponentInChildren<Animator>();

		duration = punch.duration;
		startUpTime = punch.startUpTime;
		punchID = punch.punchID;
		this.punch = punch;
	}

	override public void StateEnter()
	{
		donePunch = false;
		playerAnimator.SetTrigger(punchID);
        AudioManager.PlayMusic("Woosh");
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
		}
		else if (startUpTime <= 0 && donePunch == false)
		{
			donePunch = true;
			GameObject clone = GameObject.Instantiate(playerFSM.hitboxPrefab, playerFSM.transform);
			clone.name = punchID;

			if (playerFSM.lookDirection == "Right")
			{
				clone.GetComponent<Hitbox>().SetVariables(punch, "Right");
			}
			else // Left, if I knew more about ternary operators this would probably be prettier
			{
				clone.GetComponent<Hitbox>().SetVariables(punch, "Left");
			}
		}
	}
}