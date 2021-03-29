using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Friends : Characters
{
    public string[] spell_name = new string[3];
	public string[] spell_info = new string[3];
	public string[] spell_type = new string[3];
	public float[] spell_cost = new float[3];
	public float[] spell_cooldown = new float[3];
	[HideInInspector] public float[] spell_timeout = new float[3];
	public Sprite[] spell_sprite = new Sprite[3];
	public Spells[] Spells = new Spells[3];
	public Sprite IconHero;

	[HideInInspector] public List<SpellReload> ReloadList;

	private int start;
	private float ttime;

	public void CreateSpellReload(int num, float time) //Создать индикатор перезарядки способности
	{
		var r = Instantiate(fight.SpellReloadPref, fight.IconPos[num].position, transform.rotation);
		r.transform.SetParent(fight.Canvas);
		var Reload = r.GetComponent<SpellReload>();
		Reload.time = time;
		Reload.active = true;
		Reload.character = this;
		ReloadList.Add(Reload);
	}

	void DestroyReload() //Удалить все индикаторы перезарядки
	{
		for (int i = 0; i < ReloadList.Count; i += 1)
		{
			Destroy(ReloadList[i]);
		}
	}

	void DeactivateReload() //Деактивировать индикаторы перезарядки
	{
		for (int i = 0; i < ReloadList.Count; i += 1)
		{
			ReloadList[i].active = false;
			ReloadList[i].sprite.color = new Color(1f, 1f, 1f, 0);
			ReloadList[i].TextMesh.text = "";
		}
	}

	void ActivateReload() //Активировать индикаторы перезарядки
	{
		for (int i = 0; i < ReloadList.Count; i += 1)
		{
			ReloadList[i].active = true;
			ReloadList[i].sprite.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	public void GetSpells()
	{
		if (fight.CurrentUnit != this)
		{
			fight.IconHero.Sprite.sprite = IconHero;
			//
			fight.healthBar.SetActive(true);
			fight.manaBar.SetActive(true);
			//
			for (int i = 0; i <= 2; i += 1)
			{
				fight.icon[i].character = this;
				fight.icon[i].Name = spell_name[i];
				fight.icon[i].info = spell_info[i];
				fight.icon[i].type = spell_type[i];
				fight.icon[i].cost = spell_cost[i];
				fight.icon[i].spell = Spells[i];
				fight.icon[i].cooldown = spell_cooldown[i];
				fight.icon[i].time = spell_timeout[i];
				fight.icon[i].active = true;
				fight.Icon[i].GetComponent<SpriteRenderer>().sprite = spell_sprite[i];
			}
			if (fight.CurrentUnit != null)
			{
				fight.CurrentUnit.DeactivateReload();
			}
			fight.CurrentUnit = this;
			fight.CurrentUnitNum = fight.friends.IndexOf(this);
			ActivateReload();
			fight.health.SetHealth();
			fight.mana.SetMana();
			print("Получена информация о " + this);
		}
	}
	void RemoveSpells()
	{

	}

	void SpellsReset()
	{
		for (int i = 0; i <= 2; i += 1)
		{
			spell_timeout[i] = 0;
		}
	}
	void SpellsTimeOutDec()
	{
		for (int i = 0; i <= 2; i += 1)
		{
			if (spell_timeout[i] > 0) { spell_timeout[i] -= Time.deltaTime; } else { spell_timeout[i] = 0; };
		}
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (fight.select_friend)
			{
				fight.TargetFriend=this;
				fight.SpellUseTarget();
			}
			else if (!fight.select_enemy) 
			{
				GetSpells();
			}
		}
	}
	void Start()
	{
		fight.friends.Add(this);
		fight.friends2.Add(this);
		sprite = GetComponent<SpriteRenderer>();
		hp=maxhp;
		mana=maxmana;
	}
	void Update()
	{
        if (insp == 1)
        {
			TakeInspiration(minusCtime);
		}
        if (ttime <= 0 & start == 1)
        {
			UnTakeInspiration(minusCtime);
		}
		if (ttime > 0)
        {
            ttime -= Time.deltaTime;
            mana += regen * Time.deltaTime;
        }
		ttime -= Time.deltaTime;
		SpellsTimeOutDec();
		if (PoisonDamage>0) {TakePoisonDamage();}
		if (hp<maxhp) {TakeHealthRegen(hpreg);} else {hp=maxhp;}
		if (mana<maxmana) {TakeManaRegen(manareg);} else {mana=maxmana;}
		//
		if (hp <= 0)
		{
			if (EfIce!=null) {Destroy(EfIce.gameObject);}
			if (EfFlame!=null) {EfFlame.time=0;}
			if (Shield!=null) {Destroy(Shield.gameObject);}
			gameObject.transform.position = new Vector2(-15,0);
			fight.friends.Remove(this);
			hp = maxhp;
			mana = maxmana;
			if (fight.CurrentUnit==this)
			{
				fight.select_friend=false;
				fight.select_enemy=false;
				for (int i = 0; i <= 2; i++)
				{
					fight.Icon[i].GetComponent<SpriteRenderer>().sprite = null;
					fight.icon[i].active = false;
					fight.IconHero.Sprite.sprite = null;
					fight.healthBar.SetActive(false);
					fight.manaBar.SetActive(false);
					fight.CurrentUnitNum=-1;
					DeactivateReload();
				}
			}
		}
		//
	}

	public void TakeInspiration(float minusCd)
	{
        for (int i = 0; i <= 2; i++)
        {
            if (spell_timeout[i] > 0)
            {
				spell_timeout[i] -= minusCd;
			}
			spell_cooldown[i] -= minusCd;
        }
		insp = 0;
		start = 1;
		ttime = time;
	}

	public void UnTakeInspiration(float minusCd)
    {
        for (int i = 0; i <= 2; i++)
        {
			start = 0;
			spell_cooldown[i] += minusCd;
        }
	}

}
