using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Slash : Spells
{
    const float damage = 17.0f;
    new public void Use(Characters character)
	{
        character.TakeDamage(power*damage);
        HeroCharacter.SetReload(reloadtime);
	}
}