using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class Test : MonoBehaviour
{
	[SerializeField] private InputAction up;
	[SerializeField] private InputAction down;
	[SerializeField] private InputAction right;
	[SerializeField] private InputAction left;


	public FloatReference moveSpeed;

	void Start()
	{

	}

	void Update()
	{
		Vector3 position = this.transform.position;

		if (horizontal != 0)
			this.transform.Translate(new Vector3(	moveSpeed.value * Time.deltaTime * horizontal,
													gameObject.transform.position.y));
	}

	private float vertical
	{
		get
		{
			var keyboard = Keyboard.current;
			var vertical = 0;

			if (keyboard.wKey.isPressed)
				vertical = 1;
			else if (keyboard.sKey.isPressed)
				vertical = -1;
			return vertical;
		}
	}

	private float horizontal
	{
		get
		{
			var keyboard = Keyboard.current;
			var horizontal = 0;

			if (keyboard.dKey.isPressed)
				horizontal = 1;
			else if (keyboard.aKey.isPressed)
				horizontal = -1;
			return horizontal;
		}
	}
}
