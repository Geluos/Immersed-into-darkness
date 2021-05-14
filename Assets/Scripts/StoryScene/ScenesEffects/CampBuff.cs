using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampBuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        foreach (Characters hero in MC.friends)
        {
            if (hero.alive)
            {
                hero.TakeHeal(60);
            }
            else
            {
                hero.alive = true;
                hero.hp = 30;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
