using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spell_Lunge : Spells
{
    public int vulPercent = 30;
    public float damage = 7.0f;
    public VulnerabilityStatus VS;
    override public void Use()
    {
        //weekPercent += (int)(Math.Min(50f, 20f * (power - 1f)));
        fightController = HeroCharacter.fightController;
        foreach (var enemy in fightController.enemies)
        {
            var st = Instantiate(VS, enemy.transform);
            //st.weekPercent = weekPercent;
            st.lifetime = 12f;
            enemy.TakeDamage(damage*power);
            st.character = enemy;
        }
        HeroCharacter.SetReload(reloadtime);
    }
}
