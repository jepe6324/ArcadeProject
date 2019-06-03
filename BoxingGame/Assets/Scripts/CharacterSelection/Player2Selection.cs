using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Selection : MonoBehaviour
{
    public GameObject buttonImage;
   [HideInInspector] public int index;
    public int characterIndex;
    private int maxIndex = 3;
    public bool player2Selected = false;
    public string left;
    public string right;
    public string selectionKey;
    public bool bothSelected = false;
    Player1Selection player1Selection;
    [HideInInspector] public string character2String;



    void Update()
    {
        if (Input.GetKeyDown(left) && player2Selected == false)
        {
            index++;
        }

        if (Input.GetKeyDown(right) && player2Selected == false)
        {
            index--;
        }

        if (index < 0)
        {
            index = maxIndex;
        }

        if (index > maxIndex)
        {
            index = 0;
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

        if (Input.GetKey(selectionKey))
        {
            player2Selected = true;
            buttonImage.GetComponent<Image>().color = Selected;
        }

        if (index == 0 && player2Selected == true)
        {
            character2String = "Ikkx";
			CharacterSelector.player2Character = character2String;
		}

        else if (index == 1 && player2Selected == true)
        {
            character2String = "Angelov";
			CharacterSelector.player2Character = character2String;
		}

        else if (index == 2 && player2Selected == true)
        {
            character2String = "Pixel";
			CharacterSelector.player2Character = character2String;
		}

        else if (index == 3 && player2Selected == true)
        {
            character2String = "Ragnar";
			CharacterSelector.player2Character = character2String;
		}

        player1Selection = transform.GetComponent<Player1Selection>();

        if (player1Selection.playerSelected == true && player2Selected == true)
        {
            SceneManager.LoadScene("FightScene");
            bothSelected = true;
        }
    }

    Color Selected;

    private void Start()
    {
        Selected.r = 1;
        Selected.g = 1;
        Selected.b = 1;
        Selected.a = 0.5f;
    }
}
