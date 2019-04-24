using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
	[HideInInspector] public PlayerStateMachine playerFSM; // Removed static from these to allow for multiple players
	[HideInInspector] public Animator playerAnimator;
	[HideInInspector] public string stateID;

	public PlayerState()
	{
	}

	virtual public void StateEnter()
	{

	}

	virtual public void StateExit(PlayerState nextState)
	{

	}

    virtual public void StateUpdate()
    {
        
    }
}