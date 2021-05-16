using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spell_TearsGas : Spells
{
    public WeakStatus WS;
    override public void Use()
    {
        base.Use();
        HeroCharacter.PlayEffect("слезоточивый газ");
        fightController = HeroCharacter.fightController;
        foreach (var enemy in fightController.enemies)
        {
            var st = Instantiate(WS, enemy.transform);
            st.percent = Information.GetEffectStates("Ослабление", level, power)[0];
            st.lifetime = Information.GetSpellStates("Слезоточивый газ", level, power)[0];
            st.character = enemy;
            st.level = level;
            st.power = power;
        }
        HeroCharacter.SetReload(reloadtime);
    }
}
