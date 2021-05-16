using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Enemies
{
    public float time = 5;
    public float cooldown = 10;
    public Enemies minion;
    public Cover_Up impervious;
    public WeakStatus weak;
    public float minionHP = 15;
    public int minionCount = 2;
    public List<Enemies> minions = new List<Enemies>();

    new public void Update()
    {
        if (time > 0) { time -= Time.deltaTime; }
        else
        {
            time = cooldown;
            float r = Random.Range(0,3);
            switch(r)
            {
                case 0:
                    minions.RemoveAll(x=>x==null);
                    int count = minionCount - minions.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var enem = Instantiate(minion, transform.position, transform.rotation).GetComponent<Enemies>();
                        minions.Add(enem);
                        enem.maxhp = minionHP;
                        enem.hp = minionHP;

                        if(i==0)
                            enem.transform.position += new Vector3(-120, 80);
                        else
                            enem.transform.position += new Vector3(-120, -80);

                        enem.healthBar.SetMaxHealth();
                    }
                    break;
                case 1:
                    foreach (var x in fightController.friends)
                    {
                        var st = Instantiate(weak, x.transform);
                        st.Name = "Ослабление";
                        st.lifetime = 8;
                        st.percent = Information.GetEffectStates("Ослабление", 0, -50)[0];
                        st.power = -50;
                        st.character = x;
                        x.TakeDamage(5);
                    }
                    break;
                case 2:
                    var st2 = Instantiate(impervious, transform);
                    st2.Name = "Неуязвимость";
                    st2.koef = Information.GetEffectStates("Неуязвимость")[0];
                    st2.lifetime = Information.GetEffectStates("Неуязвимость")[1];
                    st2.character = this;
                    break;
            }
        }
        base.Update();
    }
}
