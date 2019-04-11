using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatReference
{
	public bool useConstant = false;
	public float constantValue;
	public FloatVariable variable;

	public float value
	{
		get
		{
			return useConstant ? constantValue :
								  variable.value;
		}
	}
}
