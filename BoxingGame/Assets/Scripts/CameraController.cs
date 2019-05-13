using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float xMax;
	public float xMin;

	public float playerXMax;
	public float playerXMin;

	public FloatReference shakerFactor;

	public Transform player1;
	public Transform player2;

	private Transform anchorPoint;
	private float shakeDuration;

	void Start()
	{
		anchorPoint = transform.parent;
	}

	// Update is called once per frame
	void Update()
	{
		float middlePoint = (player1.position.x + player2.position.x) / 2;
		float distance = middlePoint - anchorPoint.position.x;

		anchorPoint.Translate(new Vector2(distance, 0));
		ClampCameraPosition();
		CameraShaker();
	}

	void ClampCameraPosition()
	{
		float posX = anchorPoint.position.x;
		posX = (posX < xMin) ? xMin : ((posX > xMax) ? xMax : posX);
		anchorPoint.position = new Vector3(posX, 0, -10);
	}

	public float ClampPlayerPosition(float xPos)
	{
		return (xPos < (playerXMin + anchorPoint.position.x)) ?
				playerXMin + anchorPoint.position.x : ((xPos > (playerXMax + anchorPoint.position.x)) ? 
				playerXMax + anchorPoint.position.x : xPos);
	}

	public void CameraShaker(float duration = 0)
	{
		if (duration > 0)
			shakeDuration = duration;
		
		if (shakeDuration > 0)
		{
			shakeDuration -= Time.deltaTime;

			float x = Random.value * shakerFactor.value;
			float y = Random.value * shakerFactor.value;

			transform.localPosition = new Vector2(x, y);
		}
		else
		{
			transform.localPosition = new Vector2(0, 0);
		}
	}
}
