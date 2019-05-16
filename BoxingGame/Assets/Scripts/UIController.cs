using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	private float player1FillAmount;
	public Image player1Content;

	private float player2FillAmount;
	public Image player2Content;

	public Health player1Health;
	public Health player2Health;

	public Image player1Marker1;
	public Image player1Marker2;
	public Image player2Marker1;
	public Image player2Marker2;


	private GameplayController referee;

	// Start is called before the first frame update
	void Start()
    {
		referee = FindObjectOfType<GameplayController>();
    }

    // Update is called once per frame
    void Update()
	{
		player1FillAmount = Map(player1Health.currentHealth, 0, player1Health.maxHealth.value, 0, 1);
		player2FillAmount = Map(player2Health.currentHealth, 0, player2Health.maxHealth.value, 0, 1);

		HandleBar(player1Content, player1FillAmount);
		HandleBar(player2Content, player2FillAmount);


		switch (referee.player1Score)
		{
			case 0:
				player1Marker1.color = Color.black;
				player1Marker2.color = Color.black;
				break;
			case 1:
				player1Marker1.color = Color.white;
				player1Marker2.color = Color.black;
				break;
			case 2:
				player1Marker1.color = Color.white;
				player1Marker2.color = Color.white;
				break;
		}
		switch (referee.player2Score)
		{
			case 0:
				player2Marker1.color = Color.black;
				player2Marker2.color = Color.black;
				break;
			case 1:
				player2Marker1.color = Color.white;
				player2Marker2.color = Color.black;
				break;
			case 2:
				player2Marker1.color = Color.white;
				player2Marker2.color = Color.white;
				break;
		}
	}

	private void HandleBar(Image content, float fillAmount)
	{
		content.fillAmount = fillAmount;
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

		// (90 - 0) * (100 - 0) / (100 - 0) + 0; 
	}
}
