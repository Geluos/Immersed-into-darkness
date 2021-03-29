using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryText : MonoBehaviour
{
	[HideInInspector] public TextMeshProUGUI TextMesh; 
	
	void Awake()
	{
		TextMesh = GetComponent<TextMeshProUGUI>();
		var controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();

		controller.Text=this;
		controller.TextMesh=TextMesh;

	}
    
	//Тест
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			print(TextMesh.firstOverflowCharacterIndex);
			//print(TextMesh.GetRenderedValues()[1]);
		}
	}
	//Тест
}
