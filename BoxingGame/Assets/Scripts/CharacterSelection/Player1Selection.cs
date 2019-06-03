using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
            playerSelected = true;
        }
    }
}
