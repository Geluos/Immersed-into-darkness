using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellReload : MonoBehaviour
{
	[HideInInspector] public Friends character;
	[HideInInspector] public TextMeshProUGUI TextMesh;
	void Start()
	{
		TextMesh = GetComponent<TextMeshProUGUI>();
	}
	void Update()
	{
		if (character!=null)
		{
			TextMesh.text = Mathf.Ceil(character.reloadTime).ToString();
		}
		else Destroy(gameObject);
		if (character.reloadTime <= 0)  Destroy(gameObject);
	}
}
