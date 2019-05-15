using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonThroughKeySelection : MonoBehaviour
{
    public string key;
    public GameObject character;
    public GameObject buttonImage1;
    public GameObject buttonImage2;

    private void Start()
    {
        buttonImage1.SetActive(false);
        buttonImage2.SetActive(false);
    }


    public void Update()
    {
        if (Input.GetKey (key))
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);

            buttonImage1.SetActive(true);
            buttonImage2.SetActive(false);
            
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                character.SetActive(true);
                SceneManager.LoadScene("FightScene");
            }
        }
    }

}
