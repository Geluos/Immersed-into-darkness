using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spell_Lunge : Spells
{
    public VulnerabilityStatus VS;
    override public void Use()
    {
        HeroCharacter.PlayEffect("Выпад-вар2");
        //weekPercent += (int)(Math.Min(50f, 20f * (power - 1f)));
        fightController = HeroCharacter.fightController;
        foreach (var enemy in fightController.enemies)
        {
            var st = Instantiate(VS, enemy.transform);
            //st.weekPercent = weekPercent;
            st.koef = Information.GetEffectStates("Уязвимость", level, power)[0];
            st.lifetime = Information.GetEffectStates("Уязвимость", level, power)[1];
            enemy.TakeDamage(Information.GetSpellStates("Стремительный выпад", level, power)[0]);
            st.character = enemy;
        }
        HeroCharacter.SetReload(reloadtime);
    }
}
