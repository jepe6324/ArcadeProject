using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
	[HideInInspector] static public PlayerStateMachine playerFSM;
	[HideInInspector] static public Animator playerAnimator;
	[HideInInspector] public string stateID;

    void Start()
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