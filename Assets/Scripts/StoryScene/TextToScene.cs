using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TextToScene : MonoBehaviour
{
	[HideInInspector] public TextMeshProUGUI TextMesh;
	private BoxCollider2D collid;
	private GlobalController controller;
	public int page; //Номер страницы, на которой находится кнопка
	public string text; //Текстовое содержимое кнопки
	public string scene_name; //Имя сцены, на которую совершается переход
	public bool destroying = true; //Уничтожить ли кнопку после боевой сцены или оставить событие возобновляемым
	public Color col1;
	public Color col2;
	private int IndexInList=-1;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
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
		IndexInList=controller.ToSceneList.Count;
		controller.ToSceneList.Add(System.Tuple.Create(new Vector2(transform.position.x,transform.position.y),page,text,scene_name,destroying));
	}
	void OnMouseOver()
	{
		TextMesh.color=col1;
		if ((Input.GetMouseButtonDown(0))&&(TextMesh.text!=""))
		{
			if (destroying)
			{
				controller.ToSceneList.RemoveAt(IndexInList);
			}
			SceneManager.LoadScene(scene_name);
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