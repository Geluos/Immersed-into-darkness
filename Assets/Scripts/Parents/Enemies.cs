using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : Characters
{
	public float height;
	
	void CreateHealthBar()
	{
		var bar=Instantiate(fight.EnemyHealthBarPref, transform.position, transform.rotation);
		var HealthBar=bar.GetComponentInChildren<EnemyHealthBar>();
		HealthBar.character=this;
		HealthBar.height=height;
		HealthBar.canvas=bar;
		HealthBar.SetMaxHealth();
		HealthBar.transform.position+=new Vector3(0,height-1,0);
	}
	void Start()
    {
		fight.enemies.Add(this);
		sprite = GetComponent<SpriteRenderer>();
		hp=maxhp;
		mana=maxmana;
		CreateHealthBar();
    }
	
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (fight.select_enemy)
			{
				fight.TargetEnemy=this;
				fight.SpellUseTarget();
			}
		}
	}
	
	//Атака
	public string AttackType;//Melee-ближний Distance-дальний
	public GameObject AttackPref;
	public float AttackCooldown;
	public float AttackTimeout;
	public float DamageMin;
	public float DamageMax;
	public bool Combat;
	[HideInInspector] public Friends AttackTarget;

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
				if (!fight.friends.Find(x => x==AttackTarget)) {AttackTarget=null;} else
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
	void SetTargetRandom()
	{
		if (fight.friends.Count>0)
		{
			AttackTarget=fight.friends[Random.Range(0, fight.friends.Count)];
		}
	}
	//Атака
	
	void Update()
	{
		if ((Combat)&&(!IsFreezing))
		{
			if (fight.friends.Count==0) {Combat=false;} else
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
		if (PoisonDamage>0) {TakePoisonDamage();}
		if (hp<maxhp) {TakeHealthRegen(hpreg);} else {hp=maxhp;}
		if (mana<maxmana) {TakeManaRegen(manareg);} else {mana=maxmana;}
		if (hp<=0)
		{
			if (PoisonParticle!=null)
			{
				Destroy(PoisonParticle,5);
				PoisonParticle.GetComponent<ParticleSystem>().Stop();
			}
			if (FreezeParticle!=null) 
			{
				Destroy(FreezeParticle,5);
				FreezeParticle.GetComponent<ParticleSystem>().Stop();
			}
			if (EfIce!=null) {Destroy(EfIce.gameObject);}
			if (EfFlame!=null) {Destroy(EfFlame.gameObject);}
			fight.enemies.Remove(this);
			Destroy(gameObject);
		}
	}
}
