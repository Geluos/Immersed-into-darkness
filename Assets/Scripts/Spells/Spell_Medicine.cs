using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Medicine : Spells
{
    public float heal = 12.0f;
    override public void Use(Characters character)
	{
        character.TakeHeal(heal*power);
        HeroCharacter.SetReload(reloadtime);
	}
}