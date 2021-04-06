using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Enemies : Characters
{
	//Атака
	public string AttackType;//Melee-ближний Distance-дальний
	//public GameObject AttackPref;
	public float AttackCooldown;
	[HideInInspector] public float AttackTimeout;
	public float DamageMin;
	public float DamageMax;
	public bool Combat;
	[HideInInspector] public Friends AttackTarget;
	

	new void Start()
    {
		base.Start();
		AttackTimeout = AttackCooldown;
		fightController.enemies.Add(this);
		CreateHealthBar();
    }
	
	void OnMouseOver()
	{
		IsSelected = true;
		if (halo==null) halo = CreateHalo(Color.red);
		if (Input.GetMouseButtonDown(0))
		{
			print("Вы нажали на врага");
			if (fightController.select_enemy)
			{
				print("Враг выбран!");
				fightController.TargetEnemy=this;
				fightController.SpellUseTarget();
			}
		}
	}
	void OnMouseExit()
	{
		IsSelected = false;
		if ((halo!=null)&&(halo.color!=Color.yellow)) DestroyHalo(halo);
	}
	

	void Awake()
	{
		AttackTimeout = AttackCooldown;
		Combat=true;
	}

	void Attack()
	{
		if (AttackTarget != null && AttackTarget.alive)
		{
			if (AttackType=="Melee")
			{
				if (!fightController.friends.Find(x => x==AttackTarget)) {AttackTarget=null;} else
				{
					AttackTimeout=AttackCooldown;
					AttackTarget.TakeDamage(Random.Range(DamageMin, DamageMax));
					StartCoroutine(AttackTarget.TakingDamageAnim());
					//Instantiate(AttackPref,AttackTarget.transform.position,transform.rotation);
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
		HB.GetComponentInChildren<TextMeshProUGUI>().text = $"{Mathf.Ceil(hp)}/{Mathf.Ceil(maxhp)}";
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
			DestroyHalo(halo);
			Destroy(gameObject);
		}
	}
}
