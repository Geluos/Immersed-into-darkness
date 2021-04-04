using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : Characters
{
	//Атака
	public string AttackType;//Melee-ближний Distance-дальний
	public GameObject AttackPref;
	public float AttackCooldown;
	public float AttackTimeout;
	public float DamageMin;
	public float DamageMax;
	public bool Combat;
	[HideInInspector] public Friends AttackTarget;
	

	new void Start()
    {
		base.Start();
		fightController.enemies.Add(this);
		CreateHealthBar();
    }
	
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (fightController.select_enemy)
			{
				fightController.TargetEnemy=this;
				fightController.SpellUseTarget();
			}
		}
	}
	

	void Awake()
	{
		AttackTimeout = AttackCooldown;
		Combat=true;
	}

	void Attack()
	{
		if (AttackTarget!=null)
		{
			if (AttackType=="Melee")
			{
				if (!fightController.friends.Find(x => x==AttackTarget)) {AttackTarget=null;} else
				{
					AttackTimeout=AttackCooldown;
					AttackTarget.TakeDamage(Random.Range(DamageMin, DamageMax));
					Instantiate(AttackPref,AttackTarget.transform.position,transform.rotation);
				}
			}
		}
		else
		{
			SetTargetRandom();
		}
	}
	//Переписать
	void SetTargetRandom()
	{
		if (fightController.AliveHeroes()>0)
		{
			AttackTarget=fightController.friends[Random.Range(0, fightController.AliveHeroes())];
		}
	}
	//Атака
	
	void Update()
	{
		if ((Combat))
		{
			if (fightController.AliveHeroes()==0)
			{
				Combat=false;
			} 
			else
			{
				if (AttackTimeout<=0)
				{
					Attack();
				}
				else
				{
					AttackTimeout-=Time.deltaTime;
				}
			}
		}
		if (hp<=0)
		{
			//Удалить все эффекты
			fightController.enemies.Remove(this);
			Destroy(gameObject);
		}
	}
}
