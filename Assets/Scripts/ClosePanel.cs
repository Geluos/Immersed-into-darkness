using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Char_Canvas;
    // Update is called once per frame
    void OnMouseOver()
	{
        if (Input.GetMouseButtonDown(0))
		{
            Canvas.SetActive(false);
            Char_Canvas.SetActive(true);
        }
    }
}
