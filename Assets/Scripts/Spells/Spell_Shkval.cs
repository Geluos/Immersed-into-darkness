using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Shkval : Spells
{
    public float damage = 9.0f;
    override public void Use(Characters character)
	{
        character.TakeDamage(power*damage);
        HeroCharacter.SetReload(reloadtime);
        fightController = character.fightController;
        foreach (var enemy in fightController.enemies)
        {
            if (enemy != character)
                enemy.TakeDamage(damage / 3 * power);
        }
	}
}