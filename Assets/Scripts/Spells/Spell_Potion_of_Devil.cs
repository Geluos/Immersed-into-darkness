using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Potion_of_Devil : Spells
{
    // Start is called before the first frame update
    public ObsessionStatus status;
    override public void Use(Characters character)
    {
        print("Зелье Дьявола");
        var st = Instantiate(status, character.transform);
        st.lifetime = 8f*power;
        st.character = character;
        HeroCharacter.SetReload(reloadtime);
    }
}
