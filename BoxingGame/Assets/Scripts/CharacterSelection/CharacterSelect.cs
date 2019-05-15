using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
	public static int playerNum;
	public void characterSelect(int selectedNum)
	{
	playerNum = selectedNum;
	SceneManager.LoadScene("FightScene");
	}
}
