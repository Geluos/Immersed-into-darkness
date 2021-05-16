using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Shkval : Spells
{
    override public void Use(Characters character)
	{
        base.Use(character);
        HeroCharacter.PlayEffect("очередь");
        character.TakeDamage(Information.GetSpellStates("Стрельба на поражение", level, power)[0]);
        HeroCharacter.SetReload(reloadtime);
        fightController = character.fightController;
        foreach (var enemy in fightController.enemies)
        {
            if (enemy != character)
                enemy.TakeDamage(Information.GetSpellStates("Стрельба на поражение", level, power)[0]/4);
        }
	}
}