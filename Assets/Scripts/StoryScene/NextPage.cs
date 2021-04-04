using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextPage : MonoBehaviour
{
	[HideInInspector] public TextMeshProUGUI TextMesh;
	private BoxCollider2D collid;
	private GlobalController controller;
	public string text;
	public int page;
	public Color col1;
	public Color col2;
    void Start()
    {
		text="[Читать далее]";
        controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
		page=controller.page.Count-1;
		TextMesh = GetComponent<TextMeshProUGUI>();
		TextMesh.text=text;
		TextMesh.ForceMeshUpdate();
		collid=GetComponent<BoxCollider2D>();
		collid.size=TextMesh.GetRenderedValues();
		collid.offset+=new Vector2(TextMesh.GetRenderedValues()[0],-TextMesh.GetRenderedValues()[1])/2;
		if (page!=controller.number)
		{
			TextMesh.text="";
			TextMesh.ForceMeshUpdate();
		}
	}
	void OnMouseOver()
	{
		TextMesh.color=col1;
		if ((Input.GetMouseButtonDown(0))&&(TextMesh.text!=""))
		{
			controller.page.Add("");
			controller.number=controller.page.Count-1;
			controller.ScriptProgress++;
			Destroy(gameObject);
		}
	}
	void OnMouseExit()
	{
		TextMesh.color=col2;
	}
	void Update()
	{
		if (controller.number!=page)
		{
			TextMesh.text="";
		}
		else
		{
			TextMesh.text=text;
		}
	}
}
