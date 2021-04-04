using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PageNumber : MonoBehaviour
{
	[HideInInspector] public TextMeshProUGUI TextMesh;
	private GlobalController controller;

    void Awake()
    {
		TextMesh = GetComponent<TextMeshProUGUI>();
		controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();

		controller.PageNumber=this;
		controller.PageNumberText=TextMesh;
		
    }
}
