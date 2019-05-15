using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonThroughKeySelection : MonoBehaviour
{
    public string player1key;
    public string player2key;
    public string player1selectionKey;
    public string player2selectionkey;
    public GameObject player1character;
    public GameObject player2character;
    public GameObject player1buttonImage1;
    public GameObject player1buttonImage2;
    public GameObject player2buttonImage1;
    public GameObject player2buttonImage2;
    private bool character1selected = false;
    private bool character2selected = false;

    private void Start()
    {
        player1buttonImage1.SetActive(false);
        player1buttonImage2.SetActive(false);
        player2buttonImage1.SetActive(false);
        player2buttonImage2.SetActive(false);
    }


    public void Update()
    {
        if (Input.GetKey (player1key))
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);

            player1buttonImage1.SetActive(true);
            player1buttonImage2.SetActive(false);
        }

        else if (Input.GetKey (player2key))
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
            player2buttonImage1.SetActive(true);
            player2buttonImage2.SetActive(false);
        }

        if (Input.GetKey(player1selectionKey))
        {
            player1character.SetActive(true);
            character1selected = true;
        }

        else if (Input.GetKey(player2selectionkey))
        {
            player2character.SetActive(true);
            character2selected = true;
        }

        if (character1selected == true && character2selected == true)
        {
            SceneManager.LoadScene("FightScene");
        }
    }

}
