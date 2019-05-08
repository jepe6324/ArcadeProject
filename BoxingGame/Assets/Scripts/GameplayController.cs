using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
	public PlayerStateMachine player1;
	public PlayerStateMachine player2;

	public Text roundTimerText;

	private Health player1Health;
	private Health player2Health;

	private float roundTimer;

	private GamemodeStates state;

    void Start()
    {
		player1Health = player1.GetComponent<Health>();
		if (player1Health == null)
		{
			Debug.Log("Could not find Player 1 Health");
		}
		player2Health = player2.GetComponent<Health>();
		if (player2Health == null)
		{
			Debug.Log("Could not find Player 2 Health");
		}

		state = GamemodeStates.INTRO;
		roundTimer = 60;
    }

	void IntroUpdate()
	{
		if (player1.currentState.stateID == "Default" && player2.currentState.stateID == "Default")
		{
			player1.currentState.StateExit(new PlayerIdle(player1));
			player2.currentState.StateExit(new PlayerIdle(player2));

			state = GamemodeStates.FIGHT;
		}
	}

	void FightUpdate()
	{
		roundTimer -= Time.deltaTime;
		int timeInt = (int) roundTimer + 1 ;

		roundTimerText.text = timeInt.ToString();
		
		if (roundTimer <= 0)
		{
			player1.currentState.StateExit(new OutroState(player1));
			player2.currentState.StateExit(new OutroState(player2));

			state = GamemodeStates.TIME_OVER;
			return;
		}

		if (player1Health.currentHealth <= 0 || player2Health.currentHealth <= 0)
		{ // Double KO
			player1.currentState.StateExit(new OutroState(player1));
			player2.currentState.StateExit(new OutroState(player2));

			state = GamemodeStates.KO;
			return;
		}
	}

	void KOUpdate()
	{ // This state will do fancy stuff, like a slowdown with the losing player falling and the winner going through with his punch. Then go to match end.
		if (player1.currentState.stateID == "Default" && player2.currentState.stateID == "Default")
		{
			state = GamemodeStates.MATCH_END;
		}
	}

	void RoundOverUpdate()
	{ // This state has to determine who won. Then go to match end.
		if (player1.currentState.stateID == "Default" && player2.currentState.stateID == "Default")
		{
			state = GamemodeStates.MATCH_END;
		}
	}

	void MatchEndUpdate()
	{ // This state will make sure to wait for both characters to be done with post match stuff before exiting to character select.
	  // Such as victory pose, announcing the winner. Fanfare.
		SceneManager.LoadScene("FightScene");
	}

    // Update is called once per frame
    void Update()
    {
		switch (state)
		{
			case GamemodeStates.INTRO:
				IntroUpdate();
				break;

			case GamemodeStates.FIGHT:
				FightUpdate();
				break;

			case GamemodeStates.KO:
				KOUpdate();
				break;

			case GamemodeStates.TIME_OVER:
				RoundOverUpdate();
				break;

			case GamemodeStates.MATCH_END:
				MatchEndUpdate();
				break;
		}
	}

	enum GamemodeStates
	{
		INTRO,
		FIGHT,
		KO,
		TIME_OVER,
		MATCH_END,
	}
}
