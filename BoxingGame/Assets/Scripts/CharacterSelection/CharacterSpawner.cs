using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
	public GameObject[] Characters;
	public Transform playerSpawnPoint;
    void Start()
    {
		Instantiate(Characters[CharacterSelect.playerNum], playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

}
