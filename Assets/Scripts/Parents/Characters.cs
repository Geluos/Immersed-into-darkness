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

	public bool alive;

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
