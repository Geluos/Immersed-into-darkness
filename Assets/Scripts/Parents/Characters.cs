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
	[HideInInspector] public GameObject HB;

	public List<Status> StatusList;

	public bool alive;

	public float power = 1f;

	public float defenceMultiply = 1f;

	[HideInInspector] public Halo halo; //Ореол
	public Halo CreateHalo(Color col) //Создать ореол
	{
		var obj = (Instantiate(Resources.Load<GameObject>("Halo"), transform)).GetComponent<Halo>();
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
		var THB = Resources.Load<GameObject>("HealthBar");
		var bar=Instantiate(THB, transform);
		HB = bar;
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


	public IEnumerator TakingDamageAnim()
    {
		print("Анимация?");
		for(int i=0; i<5; ++i)
        {
			gameObject.transform.position -= new Vector3(0.2f, 0, 0);
			yield return new WaitForFixedUpdate();
		}
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < 20; ++i)
		{
			gameObject.transform.position += new Vector3(0.2f / 4, 0, 0);
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator AtakeAnim()
	{
		print("Анимация?");
		for (int i = 0; i < 5; ++i)
		{
			gameObject.transform.position += new Vector3(0.4f, 0, 0);
			yield return new WaitForFixedUpdate();
		}
		yield return new WaitForSeconds(0.2f);
		for (int i = 0; i < 20; ++i)
		{
			gameObject.transform.position -= new Vector3(0.4f / 4, 0, 0);
			yield return new WaitForFixedUpdate();
		}
	}

	public IEnumerator DoTransparent()
    {
		var spr = gameObject.GetComponent<SpriteRenderer>();
		for (int i = 1; i < 30; ++i)
		{
			spr.color = new Vector4(spr.color.r, spr.color.g, spr.color.b, spr.color.a - spr.color.a/ (500f-(float)(i)));
			yield return new WaitForFixedUpdate();
		}
		gameObject.SetActive(false);
		yield return new WaitForFixedUpdate();
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
		StartCoroutine(DoTransparent());
		alive = false;
	}
	
	public void TakeDamage(float damage)
	{
		hp = Math.Max(0f, hp-damage*defenceMultiply);
	}
	
	public void TakeHeal(float heal)
	{
		hp = Math.Min(hp + heal, maxhp);
	}

}
