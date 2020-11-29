using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Spells
{
    public GameObject fireball;
    public Transform spawn;

    public override void SpellUseTarget(Characters character)
    {
        Vector2 spawnpos = new Vector2(spawn.position.x, spawn.position.y);
        var fireb = (Instantiate(fireball, spawnpos, Quaternion.identity)).GetComponent<EfFireball>();
        fireb.character = character;
		fireb.fight=fight;
    }

}
