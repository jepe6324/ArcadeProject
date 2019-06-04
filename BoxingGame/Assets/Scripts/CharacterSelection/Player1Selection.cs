using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Selection : MonoBehaviour
{
    public GameObject buttonImage;
   [HideInInspector] public int index;
    public int characterIndex;
    private int maxIndex = 3;
    public bool playerSelected = false;
    public string left;
    public string right;
    public string selectionKey;
	public string selectionKey2;
	[HideInInspector] public string character1String;
	private Player2Selection player2Selection;
	private string upOrDown;


    void Update()
    {
        if (Input.GetKeyDown(left) && playerSelected == false)
        {
            index++;
			AudioManager.PlayMusic("Woosh");
			//if (player2Selection.index == index && player2Selection.player2Selected == true)
			//{
			//	index++;
			//}
			upOrDown = "Up";
		}

        if (Input.GetKeyDown(right) && playerSelected == false)
		{

			index--;
			AudioManager.PlayMusic("Woosh");
			//if (player2Selection.index == index && player2Selection.player2Selected == true)
			//{
			//	index--;
			//}
			upOrDown = "Down";
		}

		if (player2Selection.index == index && player2Selection.player2Selected == true)
		{
			if (upOrDown == "Up")
			{
				index++;
			}
			else
			{
				index--;
			}
		}

		if (index < 0)
        {
            index = maxIndex;

			if (player2Selection.index == index && player2Selection.player2Selected == true)
			{
				if (upOrDown == "Up")
				{
					index++;
				}
				else
				{
					index--;
				}
			}
		}

        if (index > maxIndex)
        {
            index = 0;

			if (player2Selection.index == index && player2Selection.player2Selected == true)
			{
				if (upOrDown == "Up")
				{
					index++;
				}
				else
				{
					index--;
				}
			}
		}

        if (index == characterIndex)
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);

            buttonImage.SetActive(true);
        }

        else
        {
            buttonImage.SetActive(false);
        }

        if (Input.GetKeyDown(selectionKey) || Input.GetKeyDown(selectionKey2))
        {
            playerSelected = true;
            buttonImage.GetComponent<Image>().color = Selected;
			//if (player2Selection.index == index)
			//{
			//	player2Selection.index++;
			//}
        }

        if (index == 0 && playerSelected == true)
        {
            character1String = "Ikkx";
			CharacterSelector.player1Character = character1String;
		}

        else if (index == 1 && playerSelected == true)
        {
            character1String = "Angelov";
			CharacterSelector.player1Character = character1String;
		}

        else if (index == 2 && playerSelected == true)
        {
            character1String = "Pixel";
			CharacterSelector.player1Character = character1String;
		}

        else if (index == 3 && playerSelected == true)
        {
            character1String = "Ragnar";
			CharacterSelector.player1Character = character1String;
		}
    }

    Color Selected;

    private void Start()
    {
		index = 2;
        Selected.r = 1;
        Selected.g = 1;
        Selected.b = 1;
        Selected.a = 0.5f;

		player2Selection = FindObjectOfType<Player2Selection>();
    }
}
