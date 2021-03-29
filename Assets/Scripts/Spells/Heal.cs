using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Spells
{
	public GameObject HealPref;
	public int heal;
	public override void SpellUseTarget(Characters character)
	{
		Instantiate(HealPref, character.transform.position, transform.rotation);
		character.TakeHeal(heal);
	}
}
