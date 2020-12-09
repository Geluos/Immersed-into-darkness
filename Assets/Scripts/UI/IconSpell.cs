using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpell : MonoBehaviour
{
	public string Name;
	public string info;
	public string type;
	public float cost;
	public int num;
	public float cooldown;
	public float time;
	public SpriteRenderer Sprite;
	public FightController fight;
	public Friends character;
	public Spells spell;
	public bool active=false;
    void Start()
    {
		
    }
	
	void UseSpell()
	{
		if ((!fight.select_friend)&&(!fight.select_enemy))
		{
			if ((character.spell_timeout[num]==0)&&(character.mana>=character.spell_cost[num]))
			{
				switch (type)
				{
					case "All":{
						print("Применение ненаправленной способности");
						spell.SpellUseAll(true); 
						character.spell_timeout[num]=character.spell_cooldown[num];
						character.mana-=character.spell_cost[num];
						//Upd
						character.CreateSpellReload(num,character.spell_cooldown[num]);
						//Upd
					break;}
					case "Positive":{
						print("Применение способности, направленной на союзника");
						fight.UseFriend=character;
						fight.spell=spell;
						fight.spell_num=num;
						fight.select_friend=true;
						fight.SelectFriend.SetActive(true);
					break;}
					case "Negative":{
						print("Применение способности, направленной на врага");
						fight.UseFriend=character;
						fight.spell=spell;
						fight.spell_num=num;
						fight.select_enemy=true;
						fight.SelectEnemy.SetActive(true);
					break;}
				}
			}
		} 
		else 
		{
			if (fight.spell==spell)
			{
				print("Применение способности отменено");
				fight.select_friend=false; 
				fight.select_enemy=false;
				fight.SelectFriend.SetActive(false);
				fight.SelectEnemy.SetActive(false);
			}
		}
	}
	
	void OnMouseOver()
	{ 
		if ((active)&&(character!=null))
		{
			if (Input.GetMouseButtonDown(0))
			{
				UseSpell();
			}
		}
	}
	
	private KeyCode[] Key = new KeyCode[3] {KeyCode.Q,KeyCode.W,KeyCode.E};
	void UseSpellOnKey()
	{
        if (Input.GetKeyDown(Key[num]))
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
