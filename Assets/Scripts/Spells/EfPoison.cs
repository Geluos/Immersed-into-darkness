using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfPoison : Effects
{
	void Start() 
	{
		Destroy(gameObject,1);
	}
}
