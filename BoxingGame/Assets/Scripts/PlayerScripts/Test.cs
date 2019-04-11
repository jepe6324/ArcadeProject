using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class Test : MonoBehaviour
{
	[SerializeField] private InputAction movement;

	public FloatReference moveSpeed;

	void Update()
	{
		if (horizontal != 0)
			this.transform.Translate(new Vector3(moveSpeed.value * Time.deltaTime * horizontal, 0));

		if (vertical != 0)
			this.transform.Translate(new Vector3(0, moveSpeed.value * Time.deltaTime * vertical));
	}

	private void Awake()
	{
		movement.performed += OnMovementPerformed;
		movement.cancelled += OnMovementPerformed;
	}

	private void OnMovementPerformed(InputAction.CallbackContext context)
	{
		var direction = context.ReadValue<Vector2>();

		horizontal = direction.x;
		vertical = direction.y;
	}

	private void OnDisable()
	{
		movement.Disable();
	}
	private void OnEnable()
	{
		movement.Enable();
	}

	private float vertical { get; set; }

	private float horizontal { get; set; }
}
