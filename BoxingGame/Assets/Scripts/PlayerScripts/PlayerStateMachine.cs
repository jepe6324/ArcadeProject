using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
	[HideInInspector] public PlayerState currentState;
	[HideInInspector] public string lookDirection;

	public FloatReference forwardWalkSpeed;
	public FloatReference backWalkSpeed;

	public string walkRightButton;
	public string walkLeftButton;
    // Start is called before the first frame update
    void Start()
    {
		PlayerState.playerAnimator = GetComponentInChildren<Animator>();
		PlayerState.playerFSM = this;
		currentState = new PlayerIdle();
		currentState.StateEnter();
    }

    // Update is called once per frame
    void Update()
    {
		currentState.StateUpdate();
    }
}
