using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Red_mark : Spells
{
    public VulnerabilityStatus VS;
    override public void Use(Characters character)
    {
        var st = Instantiate(VS, character.transform);
        st.koef = Information.GetEffectStates("Пробитие", level, power)[0];
        st.lifetime = Information.GetSpellStates("Красная метка", level, power)[0];
        st.character = character;
        HeroCharacter.SetReload(reloadtime);
    }
}
