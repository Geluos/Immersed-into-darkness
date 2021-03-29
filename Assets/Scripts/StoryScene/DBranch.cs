using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DBranch : MonoBehaviour
{
	[HideInInspector] public TextMeshProUGUI TextMesh;
	private BoxCollider2D collid;
	public Dialog dialog;
	private GlobalController controller;
	public string text;
	public int page;
	public int num;
	public Color col1;
	public Color col2;
    void Start()
    {
		controller=dialog.controller;
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
		controller.DBranches.Add(System.Tuple.Create(new Vector2(transform.position.x,transform.position.y),page,text,num));
    }
	
	void OnMouseOver()
	{
		TextMesh.color=col1;
		if ((Input.GetMouseButtonDown(0))&&(TextMesh.text!=""))
		{
			controller.DialogueBranch=num;
			if (dialog.ExtraPage)
			{
				controller.page.RemoveAt(controller.page.Count-1);
				controller.number--;
				controller.DialogExtraPage=false;
			}
			controller.DBranches.Clear();
			Destroy(dialog.gameObject);
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
