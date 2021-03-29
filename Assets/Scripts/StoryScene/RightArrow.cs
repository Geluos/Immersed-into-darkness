using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrow : MonoBehaviour
{
	private GlobalController controller;
	public Color col1;
	public Color col2;
	public bool visible;
	public Sprite sprite;
	public SpriteRenderer spr;
    void Start()
    {
		spr = GetComponent<SpriteRenderer>();
		spr.sprite=null;
        controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
		controller.r_arrow=this;
    }

	void OnMouseOver()
	{
		if (visible)
		{
			spr.color=col1;
			if (Input.GetMouseButtonDown(0))
			{
				controller.number++;
			}
		}
	}
	void OnMouseExit()
	{
		if (visible)
		{
			spr.color=col2;
		}
	}
	
    void Update()
    {
        if (controller.number<controller.page.Count-1)
		{
			spr.sprite=sprite;
			visible=true;
		}
		else
		{
			if (!Input.GetMouseButton(0))
			{
				spr.color=col2;
			}
			spr.sprite=null;
			visible=false;
		}
    }
}
