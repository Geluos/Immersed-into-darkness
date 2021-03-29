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
	
	[HideInInspector]  public float insp = 0;
    [HideInInspector]  public float minusCtime = 0;
    [HideInInspector]  public float time = 0;
	
	[HideInInspector] public Effects Shield;
	[HideInInspector] public float regen = 0;
	
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
		if (Shield!=null)
		{
			Shield.time-=damage/10;
			Shield.a=1;
		}
		else {hp-=damage;}
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
