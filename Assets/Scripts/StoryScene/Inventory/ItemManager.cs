using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public GlobalController controller;
	
	public List<string> Items;
	public List<Sprite> Images;
	public GameObject ItemPref;
    
	public Item ItemCreate(string name)
	{
		var item = (Instantiate(ItemPref, transform.position, transform.rotation)).GetComponent<Item>();
		item.controller=controller;
		switch (name)
		{
			case "PoisonBottle":
				item.Name="Ядовитое зелье";
				item.Info="Атаки владельца наносят больше урона и отравляют жертву";
				item.sprite=Images[0];
				item.Passive=true;
				item.PassiveLevel=0;
				item.PassiveAbility="Отравление";
				item.Damage=3;
			break;
			case "MagicAmulet":
				item.Name="Магический амулет";
				item.Info="Увеличивает максимальный запас здоровья владельца и его регенерацию";
				item.sprite=Images[1];
				item.MaxHp=50;
				item.HpReg=3f;
			break;
			
			case "IceCrystal":
				item.Name="Ледяной кристалл";
				item.Info="При активации вызывает ледяную бурю, которая замораживает всех противников и наносит им урон. Увеличивает запас и регенерацию маны";
				item.sprite=Images[2];
				item.Active=true;
				item.ActiveLevel=0;
				item.ActiveAbility="Ледяная буря";
				item.ActiveType="All";
				item.MaxMana=25;
				item.ManaReg=2;	
				item.AbilityCooldown = 9;
				item.AbilityManaCost = 50;
			break;
			
			case "DragonCane":
				item.Name="Посох дракона";
				item.Info="Атакует выбранного противника огненным снарядом, все атаки накладывают эффект поджога";
				item.sprite=Images[3];
				item.Active=true;
				item.Passive=true;
				item.ActiveLevel=0;
				item.PassiveLevel=0;
				item.ActiveAbility="Огненный шар";
				item.PassiveAbility="Огонь";
				item.ActiveType="Negative";
				item.AbilityCooldown = 9;
				item.AbilityManaCost = 30;
			break;
		}
		return item;
	}
	public Item ItemRandom()
	{
		if (Items.Count!=0)
		{
			int r = Random.Range(0,Items.Count-1);
			return ItemCreate(Items[r]);
		}
		else {return null;}
	}
}
