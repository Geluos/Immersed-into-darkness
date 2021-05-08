using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pain : Status //Боль
{
    public Suffering status; //Страдание
    new void Start()
    {
        base.Start();
        int count = 0;
        foreach (var x in character.StatusList)
        {
            if (x is Pain)
            {
                count++;
            }
        }
        if (count>=4)
        {
            foreach (var x in character.StatusList)
            {
                if (x is Pain) Destroy(x.gameObject);
            }
            var states = Information.GetEffectStates("Страдание", level, power);
            var st = Instantiate(status, character.transform);
            st.cooldown = states[0];
            st.lifetime = states[1];
            st.character = character;
        }
    }
}