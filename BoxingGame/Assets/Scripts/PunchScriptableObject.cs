using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PunchScriptableObject : ScriptableObject
{
	// Variables for player behaviour druing punch script
	public float duration;
	public float startUpTime;

	public string punchID; // This will be used to tell the character wich punch animation to do

	// Variables for spawning the hitbox
	public float damage;
	public float activeTime;
	public float sizeX;
	public float sizeY;
	public float posX;
	public float posY;
}
