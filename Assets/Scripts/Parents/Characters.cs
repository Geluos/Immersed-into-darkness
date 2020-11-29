using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{	
	public string Name;
	[HideInInspector] public SpriteRenderer sprite;
	
	public float maxhp;
	public float maxmana;
	
	[HideInInspector] public float hp;
	[HideInInspector] public float mana;
	
	public float hpreg;
	public float manareg;
	
	public FightController fight;
	
	[HideInInspector] public GameObject FreezeParticle;
	[HideInInspector] public GameObject PoisonParticle;

	[HideInInspector] public float PoisonDamage = 0;
	[HideInInspector] public float FreezingTime = 0;
	[HideInInspector] public Effects EfFlame;
	[HideInInspector] public Effects EfIce;
	[HideInInspector] public bool IsFreezing = false;
	
	public void TakePoisonDamage() 
	{
		hp-=PoisonDamage;
		sprite.color = new Color (1f-PoisonDamage*10, 1f, 1f-PoisonDamage*10, 1f);
		PoisonDamage-=0.01f*Time.deltaTime;
		if (PoisonDamage<=0)
		{
			PoisonDamage=0;
			sprite.color = new Color (1f, 1f, 1f, 1f);
			if (PoisonParticle!=null)
			{
				Destroy(PoisonParticle,5);
				PoisonParticle.GetComponent<ParticleSystem>().Stop();
				PoisonParticle=null;
			}
		}
	}
	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		FightController fight = (GameObject.FindWithTag("FightController")).GetComponent<FightController>();
		hp=maxhp;
		mana=maxmana;
	}
	
	void Update()
	{
		if (PoisonDamage>0) {TakePoisonDamage();}
		if (hp<maxhp) {TakeHealthRegen(hpreg);} else {hp=maxhp;}
		if (mana<maxmana) {TakeManaRegen(manareg);} else {mana=maxmana;}
		if (hp<=0)
		{
			Destroy(gameObject);
			if (EfIce!=null) {Destroy(EfIce.gameObject);}
			if (EfFlame!=null) {Destroy(EfFlame.gameObject);}
		}
	}
	
	public void TakeDamage(float damage)
	{
		hp-=damage;
	}
	
	public void TakeHeal(float heal)
	{
		hp+=heal;
	}
	
	public void TakeManaRegen(float reg)
	{
		mana+=reg * Time.deltaTime;
	}
	
	public void TakeHealthRegen(float reg)
	{
		hp+=reg * Time.deltaTime;
	}

}
