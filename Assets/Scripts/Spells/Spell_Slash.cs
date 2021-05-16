using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spell_Slash : Spells
{
    override public void Use(Characters character)
	{
        base.Use(character);
        HeroCharacter.PlayEffect("Способность - рассечь");
        print("Slash применен!!!");
        character.TakeDamage(Information.GetSpellStates("Рассечь",level,power)[0]);
        HeroCharacter.SetReload(reloadtime);
	}
}