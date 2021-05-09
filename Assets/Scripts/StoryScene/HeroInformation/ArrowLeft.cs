﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLeft : MonoBehaviour
{
    public HeroInformation heroInformation;

    public Color col1;
    public Color col2;
    public bool visible;
    public SpriteRenderer spriteRend;
	public Sprite sprite;
	void OnMouseOver()
	{
		if (visible)
		{
			spriteRend.color = col1;
			if (Input.GetMouseButtonDown(0))
			{
				heroInformation.num = Mathf.Max(0, heroInformation.num-1);
				heroInformation.RefreshInfo();
			}
		}
	}
	void OnMouseExit()
	{
		if (visible)
		{
			spriteRend.color = col2;
		}
	}

	void Update()
	{
		if (heroInformation.num > 0)
		{
			spriteRend.sprite = sprite;
			visible = true;
		}
		else
		{
			spriteRend.color = col2;
			spriteRend.sprite = null;
			visible = false;
		}
	}
}
