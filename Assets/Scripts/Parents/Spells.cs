using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour
{
	public string Name;
	public List<string> statusName;

	[HideInInspector] public FightController fightController;
	[HideInInspector] public Friends HeroCharacter;
	
	public string type;
	public float power;
	public int level;
	public int num;
	public Sprite sprite;

	public float reloadtime;
	
	public void Start()
	{
		num = HeroCharacter.Spells.FindIndex(x => x == this);
		power = HeroCharacter.power;
		level = HeroCharacter.SpellLevel[num];
		//print("Я мыслю");
	}

	virtual public void Use()
	{
		HeroCharacter.CurrentExp += reloadtime*2;
		power = HeroCharacter.power;
		level = HeroCharacter.SpellLevel[num];
	}

	virtual public void Use(Characters character)
	{
		HeroCharacter.CurrentExp += reloadtime*2.5f;
		power = HeroCharacter.power;
		level = HeroCharacter.SpellLevel[num];
	}
}