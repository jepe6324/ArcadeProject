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

	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
	{
		player1FillAmount = Map(player1Health.currentHealth, 0, player1Health.maxHealth.value, 0, 1);
		player2FillAmount = Map(player2Health.currentHealth, 0, player2Health.maxHealth.value, 0, 1);

		HandleBar(player1Content, player1FillAmount);
		HandleBar(player2Content, player2FillAmount);
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
