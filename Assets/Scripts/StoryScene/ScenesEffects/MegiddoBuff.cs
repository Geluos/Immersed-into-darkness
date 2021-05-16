using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegiddoBuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        foreach (Friends hero in MC.friends)
        {
            hero.alive = true;
            hero.hp = hero.maxhp;
            hero.Level++;
            hero.power += 30;
        }
        MC.heroInformation?.RefreshInfo();
    }
}
