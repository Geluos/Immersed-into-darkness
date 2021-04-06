using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpell : MonoBehaviour
{
	public string Name;
	public string info;
	public FightController fightController;
	public Friends character;
	public Spells spell;
	public SpriteRenderer Sprite;
	public bool active=false;
	public int num;
    void Start()
    {
		FightController fightController = (GameObject.FindWithTag("FightController")).GetComponent<FightController>();
    }
	
	void UseSpell()
	{
		print("UseSpell1");
		if ((!fightController.select_friend)&&(!fightController.select_enemy))
		{
			print("UseSpell2");
			if (character.reloadTime==0)
			{
				print("UseSpell2.5");
				switch (spell.type)
				{
					case "All":{
						print("Применение ненаправленной способности");
						fightController.spell=spell;
						fightController.SpellUseAll();
						//Затемнение иконок способностей
					break;}
					case "TargetFriend":{
						print("Применение способности, направленной на союзника");
						fightController.UseFriend=character;
						fightController.spell=spell;
						fightController.select_friend=true;
						fightController.SelectFriend.SetActive(true);
					break;}
					case "TargetEnemy":{
						print("Применение способности, направленной на врага");
						fightController.UseFriend=character;
						fightController.spell=spell;
						fightController.select_enemy=true;
						fightController.SelectEnemy.SetActive(true);
					break;}
				}
			}
		} 
		else 
		{
			print("UseSpell3");
			if (fightController.spell==spell)
			{
				print("Применение способности отменено");
				fightController.select_friend=false; 
				fightController.select_enemy=false;
				fightController.SelectFriend.SetActive(false);
				fightController.SelectEnemy.SetActive(false);
			}
		}
		
	}
	
	void OnMouseOver()
	{ 
		print("Mouse on Button Spell");
		if (Input.GetMouseButtonDown(0))
		{
			print("Push Button Spell");
			if ((active)&&(character!=null))
			{
				print("Попытка использовать заклинание");
				UseSpell();
			}
		}
	}
	
	private KeyCode[] Key = new KeyCode[3] {KeyCode.Q,KeyCode.W,KeyCode.E};
	void UseSpellOnKey()
	{
		//print("QWE");
        if (Input.GetKeyDown(Key[num]) && fightController.CurrentUnit == character)
        {
            UseSpell();
        }
	}
	
	
    // Update is called once per frame
	private void Update()
    {
        UseSpellOnKey();
    }
}
