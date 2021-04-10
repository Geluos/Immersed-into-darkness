using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_CoverUp : Spells
{
    public Cover_Up status;
    override public void Use(Characters character)
    {
        print("Прикрытие");
        var st = Instantiate(status, character.transform);
        st.lifetime = 8f * power;
        st.character = character;
        HeroCharacter.SetReload(reloadtime);
    }
}
