using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpBuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        foreach (Characters hero in MC.friends)
        {
            if (hero.alive)
            {
                hero.power += 30;
                hero.maxhp -= 10;
                if (hero.hp > hero.maxhp)
                    hero.hp = hero.maxhp;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
