using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Red_mark : Spells
{
    public VulnerabilityStatus VS;
    public Sprite spr;
    override public void Use(Characters character)
    {
        base.Use(character);
        HeroCharacter.PlayEffect("Метка");
        var st = Instantiate(VS, character.transform);
        st.GetComponent<SpriteRenderer>().sprite = spr;
        st.koef = Information.GetEffectStates("Пробитие", level, power)[0];
        st.lifetime = Information.GetSpellStates("Красная метка", level, power)[0];
        st.character = character;
        st.Name = "Пробитие";
        st.level = level;
        st.power = power;
        HeroCharacter.SetReload(reloadtime);
    }
}
