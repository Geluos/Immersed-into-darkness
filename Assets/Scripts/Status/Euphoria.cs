using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Euphoria : Status //Эйфория
{
    public Berserk status; //Берсерк
    new void Start()
    {
        base.Start();
        character.defenceMultiply -= Information.GetEffectStates("Эйфория", level, power)[0]/100;
        int count = 0;
        foreach (var x in character.StatusList)
        {
            if (x is Euphoria)
            {
                count++;
            }
        }
        if (count >= 3)
        {
            foreach (var x in character.StatusList)
            {
                if (x is Euphoria) Destroy(x.gameObject);
            }
            var states = Information.GetEffectStates("Берсерк", level, power);
            var st = Instantiate(status, character.transform);
            st.bonus = states[0];
            st.lifetime = states[1];
            st.character = character;
            st.level = level;
            st.power = power;
        }
    }
    new public void OnDestroy()
    {
        base.OnDestroy();
        if (character != null)
        {
            character.defenceMultiply += Information.GetEffectStates("Эйфория", level, power)[0]/100;
        }
    }
}
