using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
	public static int playerNum;
	public void characterSelect(int selectedNum)
	{
	playerNum = selectedNum;
	Application.LoadLevel("TestScene");
	}
}
