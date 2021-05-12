using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemies
{
    public PoisonStatus poison;
    bool invisible = false;
    public float timeout = 5;
    public float cooldown = 5;
    Vector3 scale;
    Vector3 startPos;

    new public void Start()
    {
        base.Start();
        startPos = transform.position;
        scale = transform.localScale;
    }
    override public void Attack()
    {
        base.Attack();
        var st = Instantiate(poison, AttackTarget.transform);
        st.Name = "Отравление";
        st.damage = Information.GetEffectStates("Отравление", 0, -50)[0];
        st.lifetime = Information.GetEffectStates("Отравление", 0, -50)[1];
        st.power = -50;
        st.period = 1f;
        st.character = AttackTarget;
    }

    new public void Update()
    {
        if (cooldown > 0) { cooldown -= Time.deltaTime; }
        else
        {
            if (!invisible)
            {
                cooldown = timeout / 3;
                invisible = true;
                transform.localScale = new Vector3(0,0,0);
                transform.position = startPos + new Vector3(Random.Range(-100, 100), Random.Range(-100, 100));
                TakeHeal(Random.Range(5,20));
                foreach (var x in StatusList)
                {
                    Destroy(x.gameObject);
                }
                StatusList.Clear();
                Combat = false;
            }
            else
            {
                cooldown = timeout;
                invisible = false;
                transform.localScale = scale;
                Combat = true;
            }
        }
        base.Update();
    }
}
