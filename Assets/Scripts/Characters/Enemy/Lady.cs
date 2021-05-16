using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lady : Enemies
{
    public float time = 5;
    public float cooldown = 6;
    public VulnerabilityStatus vulnerability;

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

    new private void Start()
    {
        base.Start();

    }


    new public void Update()
    {
        //base.Update();
        if (hp <= 0)
        {
            //Удалить все эффекты
            fightController.enemies.Remove(this);
            DestroyHalo(halo);
            Death();
        }
        HB.GetComponentInChildren<TextMeshProUGUI>().text = $"{Mathf.Ceil(hp)}/{Mathf.Ceil(maxhp)}";
        if (time > 0) { time -= Time.deltaTime; }
        else
        {
            time = cooldown;
            float r = Random.Range(0, 2);
            switch (r)
            {
                case 0:
                    SetTargetRandom();
                    StartCoroutine(AtakeAnim());
                    AttackTimeout = AttackCooldown;
                    float dam = Random.Range(DamageMin, DamageMax) * (1 + power / 100);
                    AttackTarget.TakeDamage(dam);
                    TakeHeal(dam);
                    StartCoroutine(AttackTarget.TakingDamageAnim());
                    break;
                case 1:
                    foreach (var x in fightController.friends)
                    {
                        var st = Instantiate(vulnerability, x.transform);
                        st.Name = "Уязвимость";
                        st.lifetime = 8;
                        st.koef = Information.GetEffectStates("Уязвимость", 1, 0)[0];
                        st.character = x;
                        x.TakeDamage(3);
                    }
                    break;
            }
        }
    }
}
