using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Poison : Spells
{
    const float damage = 17.0f;
    override public void Use(Characters character)
	{
        print("Отравили");
        //var st = Instantiate()
        //character.StatusList.Add()
        HeroCharacter.SetReload(reloadtime);
	}
}