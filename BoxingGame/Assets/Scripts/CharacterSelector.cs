using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class CharacterSelector
{
	public static string player1Character;
	public static string player2Character;
    Player1Selection player1Selection;
    Player2Selection player2Selection;

    void Update()
    {
        if (player1Selection.index == 0 && player1Selection.playerSelected == true)
        {
            player1Character = "Ikkx";
        }

        else if (player1Selection.index == 1 && player1Selection.playerSelected == true)
        {
            player1Character = "Angelov";
        }

        else if (player1Selection.index == 2 && player1Selection.playerSelected == true)
        {
            player1Character = "Pixel";
        }

        else if (player1Selection.index == 3 && player1Selection.playerSelected == true)
        {
            player1Character = "Ragnar";
        }

        if (player2Selection.index == 0 && player2Selection.player2Selected == true)
        {
            player2Character = "Ikkx";
        }

        else if (player2Selection.index == 1 && player2Selection.player2Selected == true)
        {
            player2Character = "Angelov";
        }

        else if (player2Selection.index == 2 && player2Selection.player2Selected == true)
        {
            player2Character = "Pixel";
        }

        else if (player2Selection.index == 3 && player2Selection.player2Selected == true)
        {
            player2Character = "Ragnar";
        }
    }
}
