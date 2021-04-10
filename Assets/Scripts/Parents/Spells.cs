using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour
{
	public string Name;
	public FightController fightController;
	public Friends HeroCharacter;
	public string type;
	public float power;
	public Sprite sprite;

	public float reloadtime;
	
	public void Start()
	{
		power = HeroCharacter.power;
		//print("Я мыслю");
	}

	virtual public void Use()
	{

	}

	virtual public void Use(Characters character)
	{
		print("Не туда воюешь!");
	}

	void Update()
    {
		power = HeroCharacter.power;
	}
}