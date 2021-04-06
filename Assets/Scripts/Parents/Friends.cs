using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public abstract class Friends : Characters
{
    public List<Spells> Spells;
	public List<IconSpell> SpellsIcons;
	public float reloadTime;

	new void Start()
	{
		base.Start();
		fightController.friends.Add(this);
		fightController.friends2.Add(this);
		hp=maxhp;
		reloadTime = 0f;
		CreateHealthBar();
		CreateIcons();
	}

	public void ActiveHero()
	{
		if (fightController.CurrentUnit != this)
		{
			/*if (fightController.CurrentUnit != null)
			{
				fightController.CurrentUnit.DeactivateReload();
			}*/
			//Повтор?
			fightController.CurrentUnit = this;
			//ActivateReload();
			//print("Получена информация о " + this);
		}
	}

	void OnMouseOver()
	{
		IsSelected = true;
		if (halo==null) halo = CreateHalo(Color.green);
		if (Input.GetMouseButtonDown(0))
		{
			DestroyHalo(halo);
			halo = CreateHalo(Color.yellow);
			if(fightController.CurrentUnit!=null)
				fightController.CurrentUnit.DestroyHalo(fightController.CurrentUnit.halo);
			fightController.CurrentUnit = this;
			print("Вы нажали на " + this);
			if (fightController.select_friend)
			{
				fightController.TargetFriend=this;
				fightController.SpellUseTarget();
			}
			if (!fightController.select_enemy) 
			{
				ActiveHero();
			}
		}
	}
	void OnMouseExit()
	{
		IsSelected = false;
		if ((halo!=null)&&(halo.color!=Color.yellow)) DestroyHalo(halo);
	}

	void CreateIcons()
	{
		for(int i=0; i<3; ++i)
		{
			Spells[i] = Instantiate(Spells[i], transform).GetComponent<Spells>();
			Spells[i].HeroCharacter = this;
			SpellsIcons.Add((Instantiate(Resources.Load<GameObject>("SpellIcon"), transform)).GetComponent<IconSpell>());
			SpellsIcons[i].Name = Spells[i].Name;
			SpellsIcons[i].info = "Витя";
			SpellsIcons[i].character = this;
			SpellsIcons[i].spell = Spells[i];
			SpellsIcons[i].Sprite.sprite = Spells[i].sprite;
			SpellsIcons[i].num = i;
			SpellsIcons[i].active = true;
			SpellsIcons[i].fightController = fightController;
			SpellsIcons[i].transform.SetParent(transform);
		}
		SpellsIcons[0].transform.position += new Vector3(-40, -height/2 + 20, 0);
		SpellsIcons[1].transform.position += new Vector3(0, -height/2, 0);
		SpellsIcons[2].transform.position += new Vector3(40, -height/2 + 20, 0);
	}

	void Update()
	{
		reloadTime = Math.Max(0f, reloadTime-Time.deltaTime);
		//!Переписать
		if(reloadTime != 0f)
        {
			for(int i=0; i<3; ++i)
            {
				SpellsIcons[i].GetComponent<SpriteRenderer>().color = Color.gray;
			}
        }
		else
        {
			for (int i = 0; i < 3; ++i)
			{
				SpellsIcons[i].GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
		HB.GetComponentInChildren<TextMeshProUGUI>().text = $"{Mathf.Ceil(hp)}/{Mathf.Ceil(maxhp)}";
		if (hp <= 0)
		{
			DestroyHalo(halo);
			Death();
		}
	}

	public void SetReload(float time)
	{
		reloadTime = time;
	}

}
