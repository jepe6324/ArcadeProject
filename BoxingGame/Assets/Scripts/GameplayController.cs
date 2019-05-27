using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
	public PlayerStateMachine player1;
	public PlayerStateMachine player2;

	public Text roundTimerText;
	public Text bigTextBox;

	public Canvas canvas;

	public VideoPlayer videoPlayer;
	public VideoClip[] clips;

	public Image bigBlackBox;

	private Health player1Health;
	private Health player2Health;

	private GamemodeStates state;
	private float timeAcumulator;
	private string bigText;
	private bool waiting;

	private int roundNumber;
	[HideInInspector] public int player1Score;
	[HideInInspector] public int player2Score;

	private float roundTimer;

	private Vector3 player1StartPos;
	private Vector3 player2StartPos;

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

		canvas.sortingOrder = 2;
		state = GamemodeStates.INTRO;
		roundNumber = 1;
		player1Score = 0;
		player2Score = 0;

		player1StartPos = player1.transform.position;
		player2StartPos = player2.transform.position;

		roundTimer = 61;

		player1.acceptInput = false;
		player2.acceptInput = false;

		bigBlackBox.color = Color.black;
		videoPlayer.Play();

		waiting = false;
	}

	void IntroUpdate() // Allows both players to complete their intro sequence before starting the match.
	{
		videoPlayer.clip = clips[roundNumber - 1];
		bigText = "Round " + roundNumber;

		timeAcumulator += Time.deltaTime;
		if ((player1.currentState.stateID == "Default" && player2.currentState.stateID == "Default") && timeAcumulator > 1)
		{
			bigTextBox.text = bigText;
			state = GamemodeStates.PRE_ROUND;
			timeAcumulator = 0;
        }
    }

	void PreRoundUpdate()
	{
		bigBlackBox.color = new Color(1,1,1,0);

		bigText = "Round " + roundNumber;
        
        bigTextBox.text = bigText;
		timeAcumulator += Time.deltaTime;

		if (timeAcumulator >= 1)
		{
            AudioManager.PlayMusic("RoundStart");
            bigTextBox.text= "";
			timeAcumulator = 0;
			player1.currentState.StateExit(new PlayerIdle(player1));
			player2.currentState.StateExit(new PlayerIdle(player2));

			bigTextBox.text = "";

			player1.acceptInput = true;
			player2.acceptInput = true;

			state = GamemodeStates.FIGHT;
			canvas.sortingOrder = -1;
		}
	} // TODO: Round X FIGHT

	void FightUpdate()
	{
		roundTimer -= Time.deltaTime;
		int timeInt = (int) roundTimer;

		roundTimerText.text = timeInt.ToString();
		
		if (roundTimer < 0)
		{
			timeAcumulator = 0;
			bigText = "Time Over";
			state = GamemodeStates.TIME_OVER;
			player1.acceptInput = false;
			player2.acceptInput = false;
			canvas.sortingOrder = 2;

			if (player2Health.currentHealth > 0)
			{
				player2.currentState.StateExit(new TimeOutState(player2));
			}
			if (player1Health.currentHealth > 0)
			{
				player1.currentState.StateExit(new TimeOutState(player1));
			}
		}
		if (player1Health.currentHealth <= 0 || player2Health.currentHealth <= 0)
		{
			timeAcumulator = 0;

            AudioManager.PlayMusic("KO");
            state = GamemodeStates.KO;
			player1.acceptInput = false;
			player2.acceptInput = false;
			canvas.sortingOrder = 2;
		}
	}

	void KOUpdate()
	{ // This state will do fancy stuff, like a slowdown with the losing player falling and the winner going through with his punch. Then go to match end.
		Time.timeScale = 0.5f;

		if ((player1.currentState.stateID == "Idle" || player1.currentState.stateID == "Default") &&
			(player2.currentState.stateID == "Idle" || player2.currentState.stateID == "Default"))
		{
			player1.currentState.StateExit(new DefaultState(player1));
			player2.currentState.StateExit(new DefaultState(player2));

			Time.timeScale = 1;
			state = GamemodeStates.END_ROUND;
			videoPlayer.Pause();
		}
	} // TODO: go to EndRoundUpdate instead of Match end

	void TimeOverUpdate()
	{
		timeAcumulator += Time.deltaTime;
		if (timeAcumulator > 3)
		{
			player1.currentState.StateExit(new DefaultState(player1));
			player2.currentState.StateExit(new DefaultState(player2));

			timeAcumulator = 0;

			Time.timeScale = 1;
			state = GamemodeStates.END_ROUND;
			videoPlayer.Pause();
		}
	} // TODO: go to EndRoundUpdate instead of Match end

	void EndRoundUpdate()
	{
		if (waiting)
		{
			timeAcumulator += Time.deltaTime;
			if (timeAcumulator > 0.5)
			{
				waiting = false;
				state = GamemodeStates.PRE_ROUND;
			}
			return;
		}

		if (player1Health.currentHealth == player2Health.currentHealth) {
			player1Score++;
			player2Score++;
            AudioManager.PlayMusic("Draw");
		} else if (player1Health.currentHealth > player2Health.currentHealth) {
			player1Score++;
        } else {
			player2Score++;
        }

		if (player1Score < 2 && player2Score < 2)
		{
			roundNumber++;
			Reset();

			videoPlayer.clip = clips[roundNumber - 1];
			videoPlayer.Play();

			player1.currentState.StateExit(new PlayerIdle(player1));
			player2.currentState.StateExit(new PlayerIdle(player2));

			bigBlackBox.color = Color.black;
			waiting = true;
		}
		else if (player1Score == 2 && player2Score == 2)
		{
			AudioManager.PlayMusic("Draw");
			state = GamemodeStates.MATCH_END;
			if (player2Health.currentHealth > 0)
			{
				player1.currentState.StateExit(new TimeOutState(player2));
				player2.currentState.StateExit(new TimeOutState(player2));
			}
		}
		else if (player1Score == 2 )
        {
            AudioManager.PlayMusic("PlayerOneWon");
            state = GamemodeStates.MATCH_END;
			player1.currentState.StateExit(new WinState(player1));
		}
        else if (player2Score == 2)
        {
            AudioManager.PlayMusic("PlayerTwoWon");
            state = GamemodeStates.MATCH_END;
			player2.currentState.StateExit(new WinState(player2));
			if (player1Health.currentHealth > 0)
			{
				player1.currentState.StateExit(new TimeOutState(player1));
			}
		}
        else
        {
            
            state = GamemodeStates.MATCH_END;
            
        }
	} // TODO: This should determine who won the round.

	void MatchEndUpdate()
	{ // This state will make sure to wait for both characters to be done with post match stuff before exiting to character select.
	  // Such as victory pose, announcing the winner. Fanfare.
		if (player1Score > player2Score) {
			bigText = "Player 1 Wins";
            
        } else if (player2Score > player1Score) {
			bigText = "Player 2 Wins";
            
        } else {
			bigText = "Draw Game";
		}

		bigTextBox.text = bigText;

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

	void Reset()
	{
		player1.Reset();
		player2.Reset();
		player1.transform.position = player1StartPos;
		player2.transform.position = player2StartPos;
		player1Health.currentHealth = player1Health.maxHealth.value;
		player2Health.currentHealth = player2Health.maxHealth.value;

		roundTimer = 60;
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
