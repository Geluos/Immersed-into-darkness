using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Окно улучшения характеристик, при повышении уровня персонажа
public class LevelUpgrade : MonoBehaviour
{
	[HideInInspector] public GlobalController controller;
	[HideInInspector] public Queue<Friends> Hero = new Queue<Friends>();
	[HideInInspector] public Queue<int> Level = new Queue<int>();
	public LUButton[] button = new LUButton[3];
	public TextMeshProUGUI info;
	public SpriteRenderer rend;
    void Start()
    {
        if (controller == null) controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
		RefreshButton();
		//RandomStates();
		Time.timeScale = 0f;
    }
	
	//public void RandomStates() //Генерация улучшений
	//{
	//	int level = Level.Peek();
	//	int koef = 1+Random.Range(0,100)/100;
	//	for (int i = 0; i<3; i++)
	//	{
	//		int r = Random.Range(1,7);
	//		switch(r)
	//		{
	//			case 1: {button[i].MaxHp+=10*(level/2)*koef; break;}
	//			case 2: {button[i].MaxMana+=10*(level/2)*koef; break;}
	//			case 3: {button[i].HpReg+=0.2f*(level/2)*koef; break;}
	//			case 4: {button[i].ManaReg+=0.2f*(level/2)*koef; break;}
	//			case 5: {button[i].Vampire+=5*(level/2)*koef; break;}
	//			case 6: {button[i].MagicPower+=2.5f*(level/2)*koef; break;}
	//		}
	//		button[i].TextRefresh();
	//	}
	//}
	
	public void RefreshButton() //Обновление улучшений
	{
		var hero = Hero.Peek();
		var level = Level.Peek();
		info.text = $"{hero.Name}\nУровень: {level}\nОпыт: {hero.CurrentExp}/{hero.RequiredExp}";
		rend.sprite = hero.spriteRend.sprite;
		for (int i = 0; i<3; i++)
		{
			button[i].spell = hero.Spells[i];
			button[i].rend.sprite = hero.Spells[i].sprite;
		}
	}
	
	void Update()
	{
		if (Hero.Count==0)
			Destroy(gameObject);
	}
}