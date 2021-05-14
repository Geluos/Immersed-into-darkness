using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : Enemies
{
    public PoisonStatus bleeding;
    public Status dodge;
    public float dodge_timeout = 15;
    private float cooldown = 5;
    private float alpha = 1f;
    override public void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        foreach (var x in StatusList)
        {
            if (x is Dodge)
            {
                if (Random.Range(0, 100) <= (x as Dodge).percent)
                {
                    alpha = 0.5f;
                    TakeHeal(Mathf.Max(0f, damage * defenceMultiply));
                    break;
                }
            }
        }
    }
    override public Halo CreateHalo(Color col) //Создать ореол
    {
        var obj = base.CreateHalo(col);
        obj.color = new Vector4(obj.color.r, obj.color.g, obj.color.b, Mathf.Floor(alpha));
        return obj;
    }
    override public void Attack()
    {
        base.Attack();
        var st = Instantiate(bleeding, AttackTarget.transform);
        //Зачем, Витя?
        st.Name = "Кровотечениe"; //С английской е на конце
        st.damage = Information.GetEffectStates("Кровотечениe")[0];
        st.lifetime = Information.GetEffectStates("Кровотечениe")[1];
        st.period = 1f;
        st.character = AttackTarget;
    }
    override public void RefreshStatusIcons() //Обновить позиции иконок
    {
        var b = false;
        foreach (var x in StatusList)
        {
            if (x is Dodge)
            {
                var r = Random.Range(0, 100);
                print(r);
                if (r <= (x as Dodge).percent)
                {
                    b = true;
                    break;
                }
            }
        }
        if (b)
        {
            if (!(StatusList[StatusList.Count - 1] is Dodge))
            {
                alpha = 0.5f;
                Destroy(StatusList[StatusList.Count - 1].gameObject);
                StatusList.RemoveAt(StatusList.Count - 1);
            }
        }
        base.RefreshStatusIcons();
    }

    new public void Update()
    {
        base.Update();
        if (cooldown > 0) { cooldown -= Time.deltaTime; }
        else
        {
            cooldown = dodge_timeout;
            bool b = true;
            foreach (var x in StatusList)
            {
                if (x is Dodge)
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                var st = Instantiate(dodge, transform);
                st.character = this;
                st.lifetime = 20;
            }
        }
        if (hp>0)
        {
            spriteRend.color = new Vector4(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, alpha);
        }
        if (alpha<1)
        {
            alpha = Mathf.Min(1,alpha+0.25f * Time.deltaTime);
            if (halo!=null)
                halo.spr.color = new Vector4(halo.spr.color.r, halo.spr.color.g, halo.spr.color.b, Mathf.Floor(alpha));
        }
    }
}
