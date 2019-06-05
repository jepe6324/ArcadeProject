using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (SceneManager.GetActiveScene().name == "FightScene")
            {
                AudioManager.StopMusic("Background Music");
                AudioManager.PlayMusic("Title Music");
            }
            SceneManager.LoadScene("TitleScene");
		}
	}
}
