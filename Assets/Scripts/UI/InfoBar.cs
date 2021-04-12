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
	float height;
	float width;
	float hshift = 0; //Горизонтальный сдвиг
	float vshift = 0; //Вертикальный сдвиг

	void Start()
	{
		TextMesh.text = text;
		TextMesh.ForceMeshUpdate();
		width = TextMesh.GetRenderedValues()[0];
		height = TextMesh.GetRenderedValues()[1];
		panel.position = (Vector2)panel.position + new Vector2(width/2 + xx, height/2 + yy);
		panel.localScale = new Vector2(width + xx, height + yy);
	}

	void Update()
	{
		if (delete) Destroy(gameObject);
		
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector2(xx + hshift, yy + vshift);
		if (Mathf.Abs(transform.position.x + xx + width - hshift) > 427) //Если текст выходит за пределы экрана по горизонтали
        {
			hshift = 427 - (transform.position.x + xx + width - hshift);
        }
		if (Mathf.Abs(transform.position.y + yy + height - vshift) > 240) //Если текст выходит за пределы экрана по вертикали
		{
			vshift = 427 - (transform.position.y + yy + height - vshift);
		}
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector2(xx + hshift, yy + vshift);
		delete = true;
	}
}
