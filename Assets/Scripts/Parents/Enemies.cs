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
	

	virtual new public void Start()
    {
		base.Start();
		AttackTimeout = AttackCooldown;

		if (fightController == null)
			print("Нет контроллера!");
		else
			print("Есть контроллера!!");
		fightController.enemies.Add(this);
    }
	
	void OnMouseOver()
	{

		IsSelected = true;
		if (halo==null) halo = CreateHalo(Color.red);
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
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
	

	new void Awake()
	{
		base.Awake();
		CreateHealthBar();
		AttackTimeout = AttackCooldown;
		Combat=true;
	}

	virtual public void Attack()
	{
		SetTargetRandom();
		StartCoroutine(AtakeAnim());
		AttackTimeout =AttackCooldown;
		AttackTarget.TakeDamage(Random.Range(DamageMin, DamageMax) * (1+power/100));
		StartCoroutine(AttackTarget.TakingDamageAnim());
		//Instantiate(AttackPref,AttackTarget.transform.position,transform.rotation);
	}
	

	void SetTargetRandom()
	{
		if (fightController.AliveHeroes() > 0)
		{
			List<Friends> tmpL = new List<Friends>();
			foreach(Friends fr in fightController.friends)
			{
				if (fr.alive)
					tmpL.Add(fr);
			}
			AttackTarget=tmpL[Random.Range(0, fightController.AliveHeroes())];
		}
	}
	//Атака

	virtual public void Update()
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
			Death();
		}
	}
}
