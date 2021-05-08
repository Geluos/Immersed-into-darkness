using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_CoverUp : Spells
{
    public Cover_Up status;
    override public void Use(Characters character)
    {
        HeroCharacter.PlayEffect("Блок");
        print("Прикрытие");
        var st = Instantiate(status, character.transform);
        st.koef = Information.GetEffectStates("Под защитой", level, power)[0];
        st.lifetime = Information.GetEffectStates("Под защитой", level,power)[1];
        st.character = character;
        HeroCharacter.SetReload(reloadtime);
    }
}
