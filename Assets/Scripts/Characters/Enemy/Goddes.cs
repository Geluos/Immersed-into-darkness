using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goddes : Enemies
{
    public float time = 5;
    public float cooldown = 10;
    public float damage;
    public WeakStatus weak;
    public PoisonStatus poison;
    public List<Enemies> minions = new List<Enemies>();

    void SetTargetRandom()
    {
        if (fightController.AliveHeroes() > 0)
        {
            List<Friends> tmpL = new List<Friends>();
            foreach (Friends fr in fightController.friends)
            {
                if (fr.alive)
                    tmpL.Add(fr);
            }
            AttackTarget = tmpL[Random.Range(0, fightController.AliveHeroes())];
        }
    }


    new public void Update()
    {
        if (time > 0) { time -= Time.deltaTime; }
        else
        {
            time = cooldown;
            float r = Random.Range(0, 2);
            switch (r)
            {
                /*case 0:
                    foreach (var x in fightController.friends)
                    {
                        var st = Instantiate(weak, x.transform);
                        st.Name = "Ослабление";
                        st.lifetime = 8;
                        st.percent = Information.GetEffectStates("Ослабление", 0, -50)[0];
                        st.power = -20;
                        st.character = x;
                        x.TakeDamage(damage);
                    }
                    break;
                case 1:
                    SetTargetRandom();
                    StartCoroutine(AtakeAnim());
                    AttackTimeout = AttackCooldown;
                    AttackTarget.TakeDamage(Random.Range(DamageMin, DamageMax) * (1 + power / 100));
                    StartCoroutine(AttackTarget.TakingDamageAnim());
                    break;
                case 2:
                    foreach (var x in fightController.friends)
                    {
                        var st = Instantiate(poison, x.transform);
                        st.Name = "Отравление";
                        st.lifetime = 8;
                        st.damage = 1;
                        st.character = x;
                        x.TakeDamage(damage);
                    }
                    break;*/
            }
        }
        base.Update();
    }
}
