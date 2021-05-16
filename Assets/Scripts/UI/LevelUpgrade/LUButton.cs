using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

//Кнопка для окошка улучшения характеристик
public class LUButton : MonoBehaviour
{
	public LevelUpgrade lvl;
	public BoxCollider2D collid;
	public SpriteRenderer rend;

	public Color MouseIn;
	public Color MouseOut;
	public Color MouseClick;

	[HideInInspector] public Spells spell;
	[HideInInspector] public MainController controller;
	public InfoBar Info;
	
	void Start()
	{
		controller = GameObject.FindWithTag("GameController").GetComponent<MainController>();
		rend.color = MouseOut;
	}	
	void OnMouseOver()
	{
		if (Info != null) Info.delete = false;
		if (controller.infoBar == null)
		{
			var hero = lvl.Hero.Peek();
			controller.infoBar = Instantiate(controller.InfoBarPref, transform.position, transform.rotation);
			Info = controller.infoBar.GetComponent<InfoBar>();
			Info.text = Information.GetSpellUpgrade(spell.Name, hero.SpellLevel[spell.num], hero.power);
			foreach (var x in spell.statusName)
			{
				Info.text += '\n' + Information.GetEffectUpgrade(x, hero.SpellLevel[spell.num], hero.power);
			}
			Info.text += $"\n\n<b>Перезарядка:</b> {spell.reloadtime}";
			//Info.text += $"\n<b> Уровень:</ b > { spell.level + 1}";
		}
		if (Input.GetMouseButton(0))
		{
			rend.color = MouseClick;
		} 
		else
		{
			rend.color = MouseIn;
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (Info != null)
			{
				Destroy(Info.gameObject);
			}
			ApplyUpgrade();
		}
	}
	void OnMouseExit()
	{
		rend.color = MouseOut;
	}
	
	public void TextRefresh() //Обновить текстовое описание улучшений
	{

	}
	
	public void ApplyUpgrade() //Применить улучшения
	{
		var hero = lvl.Hero.Dequeue();
		hero.SpellLevel[spell.num]++;
		lvl.Level.Dequeue();
		
		if (lvl.Hero.Count!=0)
		{
			lvl.RefreshButton();
		} else { Time.timeScale = 1f;}
	}
}
