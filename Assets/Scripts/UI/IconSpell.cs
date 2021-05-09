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

	public InfoBar Info;
	[HideInInspector] public MainController controller;
	void Start()
    {
		FightController fightController = (GameObject.FindWithTag("FightController")).GetComponent<FightController>();
		controller = GameObject.FindWithTag("GameController").GetComponent<MainController>();
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
						StartCoroutine(character.AtakeAnim());
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
						for (int i = 0; i < fightController.friends.Count; i++) //Quick Cast
						{
							if (fightController.friends[i].IsSelected && fightController.friends[i].alive)
							{
								fightController.TargetFriend = fightController.friends[i];
								fightController.SpellUseTarget();
								break;
							}
						}
					break;}
					case "TargetEnemy":{
						print("Применение способности, направленной на врага");
						fightController.UseFriend=character;
						fightController.spell=spell;
						fightController.select_enemy=true;
						fightController.SelectEnemy.SetActive(true);
						for (int i = 0; i < fightController.enemies.Count; i++) //Quick Cast
							{
							if (fightController.enemies[i].IsSelected)
							{
								fightController.TargetEnemy = fightController.enemies[i];
								fightController.SpellUseTarget();
								break;
							}
						}
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
		if ((active) && (character != null))
		{
			if (Info != null) Info.delete = false;
			if (controller.infoBar == null)
			{
				controller.infoBar = Instantiate(controller.InfoBarPref, transform.position, transform.rotation);
				Info = controller.infoBar.GetComponent<InfoBar>();
				Info.text = Information.GetSpellInfo(spell.Name, character.SpellLevel[num], character.power);
				foreach (var x in spell.statusName)
                {
					Info.text += '\n'+Information.GetEffectInfo(x, character.SpellLevel[num], character.power);
                }
				Info.text += $"\n\n<b>Перезарядка:</b> {spell.reloadtime}";
				//Info.text += $"\n<b> Уровень:</ b > { spell.level + 1}";
			}
			if (Input.GetMouseButtonDown(0))
			{
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
