using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
	public static float[] GetSpellStates(string name, float Level = 0, float Power = 0) //Возвращает некоторые характеристики способностей в виде массива вещественных чисел
	{
		/*
		 Для режима Бога
		 * */
		if(GameObject.FindWithTag("GameController").GetComponent<MainController>().godmode)
        {
			List<float> states1 = new List<float>();
			states1.Add(500);
			return states1.ToArray();
		}
		List<float> states = new List<float>();
		switch (name)
		{
			case "Нестандартная медицина":
				{
					states.Add((12 + Level) * (1 + Power / 100)); //damage
					break;
				}
			case "Скальпель":
				{
					states.Add((5 + Level) * (1 + Power / 100)); //damage
					break;
				}
			case "Слезоточивый газ":
				{
					states.Add((10 + Level) * (1 + Power / 100)); //time
					break;
				}
			case "Стремительный выпад":
				{
					states.Add((7 + Level) * (1 + Power / 100)); //time
					break;
				}
			case "Рассечь":
				{
					states.Add((16 + Level) * (1 + Power / 100)); //damage
					break;
				}
			case "Стрельба на поражение":
				{
					states.Add((12 + Level) * (1 + Power / 100)); //damage
					break;
				}
			case "Прострел":
				{
					states.Add((18 + Level) * (1 + Power / 100)); //damage
					break;
				}
			case "Красная метка":
				{
					states.Add((10 + Level) * (1 + Power / 100)); //time
					break;
				}
		}
		return states.ToArray();
	}

	public static float[] GetEffectStates(string name, float Level = 0, float Power = 0)
    {
		List<float> states = new List<float>();
		switch (name)
		{
			case "Отравление":
				{
					states.Add((2 + Level * 0.25f) * (1 + Power / 100)); //damage
					states.Add((7 + Level * 0.25f) * (1 + Power / 100)); //time
					break;
				}
			case "Ослабление":
				{
					states.Add((40 + Level * 5) * (1 + Power / 100)); //percent
					break;
				}
			case "Одержимость":
				{
					states.Add((80 + Level * 5) * (1 + Power / 100)); //percent
					states.Add((10 + Level) * (1 + Power / 100)); //time
					states.Add((9 + Level) * (1 + Power / 100)); //damage
					break;
				}
			case "Уязвимость":
				{
					states.Add((30 + Level * 5) * (1 + Power / 100)); //percent
					states.Add((8 + Level) * (1 + Power / 100)); //time
					break;
				}
			case "Под защитой":
				{
					states.Add((60 + Level * 5) * (1 + Power / 100)); //percent
					states.Add((7 + Level) * (1 + Power / 100)); //time
					break;
				}
			case "Пробитие":
				{
					states.Add((60 + Level * 5) * (1 + Power / 100)); //percent
					break;
				}
			case "Страдание":
				{
					states.Add((50 - Level * 5) * (1 - Power / 100)); //percent
					states.Add((40 - Level * 2) * (1 - Power / 100)); //time
					break;
				}
			case "Эйфория":
				{
					states.Add((20 + Level * 5) * (1 + Power / 100)); //percent
					states.Add((25 + Level) * (1 + Power / 100)); //time
					break;
				}
			case "Берсерк":
				{
					states.Add((70 + Level * 5) * (1 + Power / 100)); //percent
					states.Add((30 + Level) * (1 + Power / 100)); //time
					break;
				}
			case "Кровотечение":
				{
					states.Add((1 + Level * 0.25f) * (1 + Power / 100)); //damage
					states.Add((12 + Level) * (1 + Power / 100)); //time
					break;
				}
		}
		return states.ToArray();
	}

	public static string GetEffectInfo(string name, float Level = 0, float Power = 0, float LifeTime = 0, int Count = 0)
    {
		string info = "";
		float[] states = GetEffectStates(name, Level, Power);
		switch (name)
		{
			case "Отравление": { info = $"-{states[0]} HP/сек. на {states[1]} секунд. Эффекты суммируются"; break; }
			case "Ослабление": { info = $"Урон от атаки уменьшен на {states[0]}%"; break; }
			case "Одержимость": { info = $"+{states[0]}% к эффективности способностей на {states[1]} секунд. После окончания эффекта наносит {states[2]} урона"; break; }
			case "Уязвимость": { info = $"+{states[0]}% к получаемому урону на {states[1]} секунд"; break; }
			case "Под защитой": { info = $"-{states[0]}% к получаемому урону на {states[1]} секунд"; break; }
			case "Пробитие": { info = $"+{states[0]}% получаемого урона"; break; }
			case "Боль": {info = $"При получении 4 эффектов, эффекты боли обнуляются и персонаж получает эффект “Страдание”"; break;}
			case "Страдание": {info = $"+{states[0]}% к откату способностей на {states[1]} секунд"; break;}
			case "Эйфория": {info = $"-{states[0]}% к получаемому урону на {states[1]} секунд. При получении 3 эффектов, эффекты  “Эйфория” обнуляются и персонаж получает эффект “Берсерк”"; break;}
			case "Берсерк": {info = $"+{states[0]}% к наносимому урону на {states[1]} секунд"; break;}
			case "Кровотечение": {info = $"-{states[0]} HP/сек. на {states[1]} секунд"; break;}
		}
		string output = $"<b>{name}:</b>\n{info}";

		bool b = false;
		if (Count != 0) { b = true; output += $"\n<b>Кол-во эффектов:</b> {Count}"; }
		if (LifeTime != 0) { b = true; output += $"\n<b>Длительность:</b> {LifeTime}"; }
		if (b) output += "\n";

		return output;
    }
	public static string GetSpellInfo(string name, float Level = 0, float Power = 0, float cooldown = 0)
	{
		string info = "";
		float[] states = GetSpellStates(name, Level, Power);
		switch (name)
		{
			case "Нестандартная медицина": { info = $"Восстанавливает {states[0]} hp выбранному союзнику, но накладывает на него один эффект “Боль”"; break; }
			case "Психостимулятор": { info = $"Накладывает на выбранного союзника (включая себя) эффект “Эйфория” и снимает один эффект “Боль”, если таковой имеется"; break; }
			case "Скальпель": { info = $"Наносит {states[0]} урона одному врагу, накладывает один эффект “Кровотечение”"; break; }
			case "Яд": { info = $"Накладывает на выбранного врага один эффект “Отравление”"; break; }
			case "Слезоточивый газ": { info = $"Накладывает на всех врагов эффект “Ослабление” на {states[0]} секунд"; break; }
			case "Зелье дьявола": { info = $"Накладывает на выбранного союзника эффект “Одержимость”"; break; }
			case "Стремительный выпад": { info = $"Наносит {states[0]} урона всем врагам и накладывает на них эффект “Уязвимость”"; break; }
			case "Прикрытие": { info = $"Накладывает на выбранного союзника (включая себя) эффект “Под защитой”"; break; }
			case "Рассечь": { info = $"Наносит {states[0]} урона одному врагу"; break; }
			case "Стрельба на поражение": { info = $"Наносит {states[0]} урона выбранному противнику и {states[0]/4} остальным"; break; }
			case "Прострел": { info = $"Наносит {states[0]} урона"; break; }
			case "Красная метка": { info = $"Выбранный противник получит “Пробитие” на {states[0]} секунд"; break; }
		}

		string output = $"<b>{name}:</b>\n{info}";

		bool b = false;
		if (cooldown != 0) { b = true; output += $"\n<b>Перезарядка:</b> {cooldown}"; }
		if (b) output += "\n";

		return output;
	}

	//public string GetHeroSpellInfo(int num) //Возвращает строку с информацией о способности героя
	//{
	//	string name = HeroSpellName[num];
	//	float Level = HeroSpellLevel[num];
	//	float Power = HeroMagicPower[num / 3];
	//	float cost = HeroSpellCost[num];
	//	float cooldown = HeroSpellCooldown[num];

	//	return GetSpellInfo(name, Level, Power, cost, cooldown);
	//}
}
