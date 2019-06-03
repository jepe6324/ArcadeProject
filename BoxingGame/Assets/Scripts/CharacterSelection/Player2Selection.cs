using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player2Selection : MonoBehaviour
{
    public GameObject buttonImage;
    private int index;
    public int characterIndex;
    private int maxIndex = 3;
    public bool player2Selected = false;
    public string left;
    public string right;
    public string selectionKey;
    public bool bothSelected = false;
    Player1Selection player1Selection;



    void Update()
    {
        if (Input.GetKeyDown(left))
        {
            index++;
        }

        if (Input.GetKeyDown(right))
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
        }

        player1Selection = transform.GetComponent<Player1Selection>();

        if (player1Selection.playerSelected == true && player2Selected == true)
        {
            SceneManager.LoadScene("FightScene");
            bothSelected = true;
        }
    }
}
