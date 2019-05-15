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
	public Text playerXWon;

	private Health player1Health;
	private Health player2Health;

	private float roundTimer;
	private GamemodeStates state;
	private float timeAcumulator;
	private string winText;

	private int roundNumber;

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
		roundNumber = 1;
    }

	void IntroUpdate()
	{
		if (player1.currentState.stateID == "Default" && player2.currentState.stateID == "Default")
		{
			player1.currentState.StateExit(new PlayerIdle(player1));
			player2.currentState.StateExit(new PlayerIdle(player2));

			state = GamemodeStates.PRE_ROUND;
		}
	}

	void PreRoundUpdate()
	{

	} // TODO: Round X FIGHT

	void FightUpdate()
	{
		roundTimer -= Time.deltaTime;
		int timeInt = (int) roundTimer + 1 ;

		roundTimerText.text = timeInt.ToString();
		
		if (roundTimer < 0)
		{
			winText = "Time Over";
			state = GamemodeStates.TIME_OVER;
			return;
		}

		if (player1Health.currentHealth <= 0 || player2Health.currentHealth <= 0)
		{ // Double KO
			winText = "Double K.O";

			state = GamemodeStates.KO;
			return;
		}
	} // TODO: This should not have resposibility of determining the winner.

	void KOUpdate()
	{ // This state will do fancy stuff, like a slowdown with the losing player falling and the winner going through with his punch. Then go to match end.
		Time.timeScale = 0.5f;

		if (player1.currentState.stateID == "Idle")
		{
			player1.currentState.StateExit(new OutroState(player1));
		}
		if (player2.currentState.stateID == "Idle")
		{
			player2.currentState.StateExit(new OutroState(player2));
		}

		if (player1.currentState.stateID == "Default" && player2.currentState.stateID == "Default")
		{
			Time.timeScale = 1;
			state = GamemodeStates.END_ROUND;
		}
	} // TODO: go to EndRoundUpdate instead of Match end

	void TimeOverUpdate()
	{ // This state has to determine who won. Then go to match end.
		playerXWon.text = winText;

		if (player1.currentState.stateID == "Idle")
		{
			player1.currentState.StateExit(new OutroState(player1));
		}
		if (player2.currentState.stateID == "Idle")
		{
			player2.currentState.StateExit(new OutroState(player2));
		}



		if (player1.currentState.stateID == "Default" && player2.currentState.stateID == "Default")
		{
			if (player1Health.currentHealth > player2Health.currentHealth)
			{
				winText = "Player 1 Wins";
			}
			else if (player1Health.currentHealth < player2Health.currentHealth)
			{
				winText = "Player 2 Wins";
			}
			else
			{
				winText = "Draw Match";
			}

			state = GamemodeStates.MATCH_END;
		}
	} // TODO: go to EndRoundUpdate instead of Match end

	void EndRoundUpdate()
	{

	} // TODO: This should determine who won the round.

	void MatchEndUpdate()
	{ // This state will make sure to wait for both characters to be done with post match stuff before exiting to character select.
	  // Such as victory pose, announcing the winner. Fanfare.
		playerXWon.text = winText;

		timeAcumulator += Time.deltaTime;
		if (timeAcumulator > 4)
		{
			SceneManager.LoadScene("FightScene");
			timeAcumulator = 0;
		}
	}
    // Update is called once per frame
    void Update()
    {
		switch (state)
		{
			case GamemodeStates.INTRO:
				IntroUpdate();
				break;

			case GamemodeStates.PRE_ROUND:
				PreRoundUpdate();
				break;

			case GamemodeStates.FIGHT:
				FightUpdate();
				break;

			case GamemodeStates.KO:
				KOUpdate();
				break;

			case GamemodeStates.TIME_OVER:
				TimeOverUpdate();
				break;

			case GamemodeStates.END_ROUND:
				EndRoundUpdate();
				break;

			case GamemodeStates.MATCH_END:
				MatchEndUpdate();
				break;
		}
	}

	enum GamemodeStates
	{
		INTRO,
		PRE_ROUND,
		FIGHT,
		KO,
		TIME_OVER,
		END_ROUND,
		MATCH_END,
	}
}
