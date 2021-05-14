using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Shoot : Spells
{
    override public void Use(Characters character)
	{
        HeroCharacter.PlayEffect("Выстрел");
        character.TakeDamage(Information.GetSpellStates("Прострел", level, power)[0]);
        HeroCharacter.SetReload(reloadtime);
	}
}