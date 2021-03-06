﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goddes : Enemies
{
    public float time = 5;
    public float cooldown = 10;
    public float damage;
    public WeakStatus weak;
    public PoisonStatus poison;
    public bool razmes = true;
    private float allTime = 0f;

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
        if(razmes)
            foreach(Friends f in fightController.friends)
            {
                f.gameObject.transform.position += new Vector3(20, 0);
            }
        
    }


    new public void Update()
    {
        allTime+= Time.deltaTime;
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
            float r = Random.Range(0, 3);
            switch (r)
            {
                case 0:
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
                        st.period = 1;
                        st.damage = 1;
                        st.character = x;
                        //x.TakeDamage(damage);
                    }
                    break;
            }
        }

        if(razmes && allTime > 12)
        {
            SetTargetRandom();
            StartCoroutine(AtakeAnim());
            StartCoroutine(AttackTarget.TakingDamageAnim());
        }
    }
}
