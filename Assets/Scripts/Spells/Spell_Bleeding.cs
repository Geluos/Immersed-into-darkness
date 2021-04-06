using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speel_Bleeding : Spells
{
    const float damage = 5.0f;
    PoisonStatus PS;
    override public void Use(Characters character)
	{
        print("Отравили");
        var st = Instantiate(PS, character.transform);
        st.damage = damage * power;
        st.lifetime = 10f;
        st.period = 2f;
        //character.StatusList.Add()
        HeroCharacter.SetReload(reloadtime);
	}
}