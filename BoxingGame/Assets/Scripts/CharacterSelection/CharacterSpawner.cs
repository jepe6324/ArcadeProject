using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
	public GameObject character1;
    public GameObject character2;
	
    void Start()
    {
		if (CharacterSelect.playerNum == 0)
        {
            character2.SetActive(true);
        }

        else if (CharacterSelect.playerNum == 1)
        {
            character1.SetActive(true);
        }
    }

}
