using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Spells
{
	public GameObject ShieldPref;
	public override void SpellUseTarget(Characters character)
	{
		if (character.Shield==null)
		{
			var Shield = (Instantiate(ShieldPref, character.transform.position, transform.rotation)).GetComponent<EfShield>();;
			character.Shield=Shield;
		} else {character.Shield.time=10;}
	}
}
