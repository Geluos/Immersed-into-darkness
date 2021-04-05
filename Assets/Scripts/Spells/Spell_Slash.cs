using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Slash : Spells
{
    const float damage = 17.0f;
    override public void Use(Characters character)
	{
        print("Slash применен!!!");
        character.TakeDamage(power*damage);
        HeroCharacter.SetReload(reloadtime);
	}
}