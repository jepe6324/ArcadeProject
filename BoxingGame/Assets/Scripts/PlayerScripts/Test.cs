using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public FloatReference testFloat;

	void Start()
	{

	}

	void Update()
	{
		Vector3 position = this.transform.position;


		this.transform.Translate(new Vector3(	testFloat.value * Time.deltaTime,
												gameObject.transform.position.y));
	}
}
