using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBar : MonoBehaviour
{
	public TextMeshProUGUI TextMesh; //Текст
	public Transform panel; //Задний фон текста

	private BoxCollider2D collid;
	private SpriteRenderer render;
	[HideInInspector] public string text;
	[HideInInspector] public bool delete = false;

	float xx = 0.1f;
	float yy = 0.05f;

	void Start()
	{
		TextMesh.text = text;
		TextMesh.ForceMeshUpdate();
		panel.position = (Vector2)panel.position + new Vector2(TextMesh.GetRenderedValues()[0]/2 + xx, TextMesh.GetRenderedValues()[1]/2 + yy);
		panel.localScale = new Vector2(TextMesh.GetRenderedValues()[0] + xx, TextMesh.GetRenderedValues()[1] + yy);
	}

	void Update()
	{
		if (delete) Destroy(gameObject);
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector2(xx, yy);
		delete = true;
	}
}
