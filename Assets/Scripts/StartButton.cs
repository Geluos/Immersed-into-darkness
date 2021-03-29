using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("FightScene");
        }
    }

    private void Update() 
    {
        if(Input.GetKey("escape"))
		{
			Application.Quit();
		}
    }
}
