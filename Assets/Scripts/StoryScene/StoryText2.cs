using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryText2 : MonoBehaviour
{
	[HideInInspector] public TextMeshProUGUI TextMesh; 
    void Awake()
    {
		TextMesh = GetComponent<TextMeshProUGUI>();
		var controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();

		controller.TextMesh2=TextMesh;
    }
}
