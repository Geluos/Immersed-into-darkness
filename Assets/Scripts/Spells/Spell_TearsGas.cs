using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spell_TearsGas : Spells
{
    public int weekPercent = 40;
    public WeakStatus WS;
    override public void Use()
    {
        weekPercent += (int)(Math.Min(50f, 20f * (power - 1f)));
        fightController = HeroCharacter.fightController;
        foreach (var enemy in fightController.enemies)
        {
            var st = Instantiate(WS, enemy.transform);
            st.weekPercent = weekPercent;
            st.lifetime = 15f;
            st.character = enemy;
        }
        HeroCharacter.SetReload(reloadtime);
    }
}
