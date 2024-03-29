﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public abstract class Characters : MonoBehaviour
{	
	public string Name;
	public float maxhp;
	public float hp;
	public float HpRegen = 0; //Регенерация здоровья
	public float CooldownReduction = 0; //Уменьшение перезарядки способностей
	public FightController fightController;
	public float height;
	[HideInInspector] public bool IsSelected = false;
	[HideInInspector] public GameObject HB;
	public SpriteRenderer spriteRend;

	public List<Status> StatusList;

	public bool alive;

	public float power = 0;

	public float defenceMultiply = 1f;

	[HideInInspector] public Halo halo; //Ореол
	public HealthBar healthBar;
	virtual public Halo CreateHalo(Color col) //Создать ореол
	{
		var obj = (Instantiate(Resources.Load<GameObject>("Halo"), transform)).GetComponent<Halo>();
		if (alive)
		{
			
			obj.spr.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			obj.transform.position = transform.position;
			obj.transform.localScale = transform.localScale;
			obj.color = col;
		}
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
		healthBar = bar.GetComponentInChildren<HealthBar>();
		healthBar.transform.parent.position += new Vector3(0, height/2+4f, 0);
		healthBar.character=this;
		healthBar.SetMaxHealth();
	}

	virtual public void RefreshStatusIcons() //Обновить позиции иконок
    {
		for (int i = 0; i<StatusList.Count; i++)
        {
			StatusList[i].transform.position = transform.position + new Vector3(-(StatusList.Count-1)*16+i*32,height/2+32,-1);
        }
    }
    public void Awake()
    {
		//Расчет высоты спрайта
		spriteRend = gameObject.GetComponent<SpriteRenderer>();
		height = spriteRend.sprite.bounds.size.y;
    }

    public void Start()
	{
		fightController = (GameObject.FindWithTag("FightController")).GetComponent<FightController>();
		hp=maxhp;
		alive = true;
		var AS = gameObject.AddComponent<AudioSource>();
		AS.outputAudioMixerGroup = Resources.Load<AudioMixer>("AudioMixer").FindMatchingGroups("Effects")[0];
	}

	public void PlayEffect(string name)
    {
		gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(name);
		gameObject.GetComponent<AudioSource>().Play();
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
		PlayEffect("Звук удара по тарелке");
		alive = false;
		StartCoroutine(DoTransparent());
		
	}
	public void CreatePopUpNumbers(float number)
    {
		if (fightController != null)
		{
			if (number != 0)
			{
				var popUpNumbers = Instantiate(fightController.PopUpNumbersPref, transform.position + new Vector3(0, height / 4), transform.rotation).GetComponent<PopUpNumbers>();
				popUpNumbers.transform.position += new Vector3(UnityEngine.Random.Range(-48f, 48f), UnityEngine.Random.Range(-48f, 48f));
				popUpNumbers.number = number;
			}
		}
    }
	virtual public void TakeDamage(float damage)
	{
		CreatePopUpNumbers(Mathf.Ceil(-damage * Mathf.Max(0, defenceMultiply)));
		hp = Math.Max(0f, hp-damage*Mathf.Max(0,defenceMultiply));
	}
	
	public void TakeHeal(float heal)
	{
		CreatePopUpNumbers(Mathf.Floor(heal));
		hp = Math.Min(hp + heal, maxhp);
	}

}
