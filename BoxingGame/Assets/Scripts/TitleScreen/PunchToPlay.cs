using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PunchToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Player1Punch") ||
			Input.GetButton("Player1Uppercut") ||
			Input.GetButton("Player2Punch") ||
			Input.GetButton("Player2Uppercut"))
		{
			SceneManager.LoadScene("FightScene"); // TODO: Change this to character select.
		}
    }
}
