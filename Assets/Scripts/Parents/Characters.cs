using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Characters : MonoBehaviour
{	
	public string Name;
	public float maxhp;
	public float hp;
	public FightController fightController;
	public float height;
	[HideInInspector] public bool IsSelected = false;

	public List<Status> StatusList;

	public bool alive;

	public Halo halo; //Ореол
	public Halo CreateHalo(Color col) //Создать ореол
	{
		var obj = (Instantiate(Resources.Load<GameObject>("Halo"))).GetComponent<Halo>();
		obj.spr.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
		obj.transform.position = transform.position;
		obj.transform.localScale = transform.localScale;
		obj.color = col;
		return obj;
	}
	public void DestroyHalo(Halo obj) //Удалить ореол
	{
		if (obj!=null)
		{
			Destroy(obj.gameObject);
		}
	}

	public void CreateHealthBar()
	{
		GameObject HB = Resources.Load<GameObject>("HealthBar");
		var bar=Instantiate(HB, transform);
		var HealthBar = bar.GetComponentInChildren<HealthBar>();
		HealthBar.transform.parent.position += new Vector3(0, height/2+4f, 0);
		HealthBar.character=this;
		HealthBar.SetMaxHealth();
	}
	
	public void Start()
	{
		FightController fightController = (GameObject.FindWithTag("FightController")).GetComponent<FightController>();
		hp=maxhp;
		alive = true;

		//Расчет высоты спрайта
		SpriteRenderer spt;
		spt = gameObject.GetComponent<SpriteRenderer>();
		height = spt.sprite.bounds.size.y;
	}
	
	void Update()
	{
		if (hp<=0)
		{
			//Уничтожать объект - плохое решение. Будем делать неактивным
			//Destroy(gameObject);
			//Уничтожить эффекты эффектов
			Death();
		}
	}

	public void Death()
	{
		gameObject.SetActive(false);
		alive = false;
	}
	
	public void TakeDamage(float damage)
	{
		hp = Math.Max(0f, hp-damage);
	}
	
	public void TakeHeal(float heal)
	{
		hp = Math.Min(hp + heal, maxhp);
	}

}
