using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvIconHero : MonoBehaviour
{
	public GlobalController controller;
	public SpriteRenderer Sprite;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
		controller.IconHeroSprite = GetComponent<SpriteRenderer>();
		controller.IconHeroSprite.sprite = controller.HeroSprite[controller.CurrentHero];
	}
}
