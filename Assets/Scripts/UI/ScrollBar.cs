using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollBar : MonoBehaviour
{
    public Scrollbar scrollBar;
	public float koef;
	public void Update()
	{
		scrollBar.value+=Input.GetAxis("Mouse ScrollWheel")*koef;
		//if (scrollBar.value > 1) { scrollBar.value = 1; }
		//if (scrollBar.value < 0) { scrollBar.value = 0; }

	}
}
