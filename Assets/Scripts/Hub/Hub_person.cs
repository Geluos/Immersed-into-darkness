using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub_person : MonoBehaviour
{
    public GameObject Canvas;
    void OnMouseOver()
	{
        if (Input.GetMouseButtonDown(0))
		{
            //И где-то здесь передача данных
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
