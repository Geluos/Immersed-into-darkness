using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub_person : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject CharCanvas;
    void OnMouseOver()
	{
        if (Input.GetMouseButtonDown(0))
		{
            CharCanvas.SetActive(false);
            Canvas.SetActive(true);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
