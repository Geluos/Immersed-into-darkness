using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Shoot : Spells
{
    const float damage = 18.0f;
    override public void Use(Characters character)
	{
        character.TakeDamage(power*damage);
        HeroCharacter.SetReload(reloadtime);
	}
}