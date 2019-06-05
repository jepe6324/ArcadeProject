using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleDetector : MonoBehaviour
{
	public float maxIdle; // How long the game can be idle before we return to splash screen.
	private float idleTime; // How long the game has currently been idle

	// Start is called before the first frame update
	void Start()
	{
		idleTime = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (!Input.anyKey)
		{
			idleTime += Time.deltaTime;
		}
		else
		{
			idleTime = 0;
		}

		if (idleTime > maxIdle)
		{
			AudioManager.StopMusic("Title Music");
			SceneManager.LoadScene("SplashImageIntro");
		}
	}
}