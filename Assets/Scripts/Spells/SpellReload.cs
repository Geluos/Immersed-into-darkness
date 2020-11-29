using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellReload : MonoBehaviour
{
	[HideInInspector] public float time;
	[HideInInspector] public bool active; 
	[HideInInspector] public Friends character; 
	[HideInInspector] public TextMeshProUGUI TextMesh; 
	[HideInInspector] public SpriteRenderer sprite; 
    void Start()
    {
		TextMesh = GetComponent<TextMeshProUGUI>();
		sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (active)
		{
			TextMesh.text=Mathf.Ceil(time).ToString();
		}
		if (time<=0)
		{
			Destroy(gameObject);
			character.ReloadList.Remove(this);
		}
		else
		{
			time-=Time.deltaTime;
		}
    }
}