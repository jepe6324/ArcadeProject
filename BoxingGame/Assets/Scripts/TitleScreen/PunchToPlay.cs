using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PunchToPlay : MonoBehaviour
{
	public string[] PunchButtons;
	public string nextScene;
    
	// Start is called before the first frame update
    void Start()
    {
		AudioManager.PlayMusic("Title Music");
    }

    // Update is called once per frame
    void Update()
    {
		foreach(string element in PunchButtons)
		{
			if (Input.GetButton(element))
			{
				AudioManager.PlayMusic("Punch");
				SceneManager.LoadScene(nextScene);
			}
		}
    }
}
