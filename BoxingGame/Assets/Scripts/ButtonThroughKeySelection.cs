using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonThroughKeySelection : MonoBehaviour
{
    public string key;
    public KeyCode offKey;
    //OnHover bla;

    public GameObject image;
    private bool isActive = false;
    //void IsHovering(bool value)
    //{
    //    Debug.Log("IsHovering::Value " + value);
    //}

    void Update()
    {
        if (Input.GetKeyDown(key)) 
        {
            if (isActive)
            {
                image.SetActive(false);
                isActive = false;
                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                image.SetActive(true);
                isActive = true;
                EventSystem.current.SetSelectedGameObject(this.gameObject);
            }
            //image.SetActive(false);
            //EventSystem.current.SetSelectedGameObject(this.gameObject);

          //if (EventSystem.current.currentSelectedGameObject == this.gameObject)
          //{
              
          //}

          //else if (EventSystem.current.currentSelectedGameObject != this.gameObject)
          //{
          //      image.SetActive(false);
          //}
            
        }
        
    }
}
