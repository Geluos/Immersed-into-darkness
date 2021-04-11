using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Slash : Spells
{
    const float damage = 16.0f;
    override public void Use(Characters character)
	{
        character.PlayEffect("Способность - рассечь");
        print("Slash применен!!!");
        character.TakeDamage(power*damage);
        HeroCharacter.SetReload(reloadtime);
	}
}