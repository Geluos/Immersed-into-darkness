using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject Canvas;
    public int temp = 10;
    // Update is called once per frame
    void OnMouseOver()
	{
        if (Input.GetMouseButtonDown(0))
		{
            Canvas.SetActive(false);
            temp++;
        }
    }
}
