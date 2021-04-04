using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public GlobalController controller;
	
    public string Name = ""; //Название предмета
	public string Info = ""; //Описание предмета
	public int Cost = 0; //Стоимость предмета
	
	public Sprite sprite; //Спрайт предмета
	
	public bool Active = false;	//Есть ли активная способность
	public bool Passive = false; //Есть ли пассивная способность
	
	public string ActiveAbility = ""; //Название активной способности
	public string PassiveAbility = ""; //Название пассивной способности
	public float  AbilityCooldown = 0; //Перезарядка активной способности
	public float  AbilityManaCost = 0; //Стоимость активной способности
	public int    ActiveLevel = 0; //Уровень активной способности
	public int    PassiveLevel = 0; //Уровень пассивной способности
	public string ActiveType = ""; //Тип пассивной способности
	
	public float MaxHp = 0;	//Бонус к максимальному здоровью
	public float MaxMana = 0; //Бонус к максимальной мане
	public float HpReg = 0;	//Бонус к восстановлению здоровья
	public float ManaReg = 0; //Бонус к восстановлению маны
	public float Cooldown = 0; //Бонус к снижению перезарядки способности
	public float Vampire = 0; //Бонус к вампиризму
	public float Damage = 0; //Бонус к урону от физических атак
	public float AttackCooldown = 0; //Бонус к снижению перезарядки атаки
	public float ItemMagicPower = 0; //Коэффициент силы заклинаний
	
	public void ToInventory()
	{
		if (!controller.InventoryIsFull())
		{
			for (int i = 0; i<14; i++)
			{
				if (!controller.ItemNotEmpty[i])
				{
					controller.ItemName[i] = Name;							controller.ItemCost[i] = Cost;							controller.ItemActive[i] = Active;
					controller.ItemInfo[i] = Info;							controller.ItemSprite[i] = sprite;						controller.ItemPassive[i] = Passive;		
					controller.ItemActiveAbility[i] = ActiveAbility;		controller.ItemMaxHp[i] = MaxHp;						controller.ItemHpReg[i] = HpReg;
					controller.ItemPassiveAbility[i] = PassiveAbility;		controller.ItemMaxMana[i] = MaxMana;					controller.ItemManaReg[i] = ManaReg;		
					controller.ItemCooldown[i] = Cooldown;					controller.ItemVampire[i] = Vampire;					controller.ItemDamage[i] = Damage;
					controller.ItemAbilityCooldown[i] = AbilityCooldown;	controller.ItemAbilityManaCost[i] = AbilityManaCost;	controller.ItemAttackCooldown[i] = AttackCooldown;
					controller.ItemMagicPower[i] = ItemMagicPower;			controller.ItemActiveLevel[i] = ActiveLevel;			controller.ItemPassiveLevel[i] = PassiveLevel;
					controller.ItemNotEmpty[i] = true;						controller.ItemActiveType[i] = ActiveType;
					if (i>7) {controller.ItemTakeStates(i);}
					break;
				}
			}
			Destroy(gameObject);
		}
	}
}
