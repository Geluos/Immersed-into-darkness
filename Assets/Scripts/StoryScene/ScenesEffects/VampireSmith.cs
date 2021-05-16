using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireSmith : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        foreach (Characters hero in MC.friends)
        {
            if (hero.alive)
            {
                hero.power += 12;
                hero.hp = System.Math.Max(hero.hp - 15, 1);
            }
        }
        MC.heroInformation?.RefreshInfo();
    }
}
