using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Potion_of_Devil : Spells
{
    // Start is called before the first frame update
    public ObsessionStatus status;
    override public void Use(Characters character)
    {
        HeroCharacter.PlayEffect("Зелье дьявола");
        print("Зелье Дьявола");
        var st = Instantiate(status, character.transform);
        st.koef = Information.GetEffectStates("Одержимость", level, power)[0];
        st.lifetime = Information.GetEffectStates("Одержимость",level,power)[1];
        st.character = character;
        st.damage = Information.GetEffectStates("Одержимость", level, power)[2];
        st.level = level;
        st.power = power;
        HeroCharacter.SetReload(reloadtime);
    }
}
