using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrowHero : MonoBehaviour
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
    }

	void OnMouseOver()
	{
		if (visible)
		{
			spr.color=col1;
			if (Input.GetMouseButtonDown(0))
			{
				controller.CurrentHero++;
				controller.InvCellHero[0].index = 8+controller.CurrentHero*2;
				controller.InvCellHero[1].index = 9+controller.CurrentHero*2;
				controller.IconHeroSprite.sprite = controller.HeroSprite[controller.CurrentHero];
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
        if (controller.CurrentHero<2)
		{
			spr.sprite=sprite;
			visible=true;
		}
		else
		{
			spr.color=col2;
			spr.sprite=null;
			visible=false;
		}
    }
}
