using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalController : MonoBehaviour
{
	[HideInInspector] public StoryText Text;
	[HideInInspector] public PageNumber PageNumber;
	[HideInInspector] public TextMeshProUGUI PageNumberText;
	[HideInInspector] public TextMeshProUGUI TextMesh;//Видимый, для текущей страницы
	[HideInInspector] public TextMeshProUGUI TextMesh2;//Невидимый, для обработки на последней странице
	
	public ItemSelected Selected;
	
	public GameObject TCreator;	
	public GameObject TextToScene;	
	public GameObject DialogPref;
	public GameObject BranchPref;
	public GameObject NextPage;
	public GameObject Canvas;
	public GameObject InvCellPref;
	public GameObject CellSpritePref;
	[HideInInspector] public RightArrow r_arrow;
	[HideInInspector] public LeftArrow l_arrow;
	[HideInInspector] public TextCreator TextCreator;
	/*[HideInInspector]*/ public List<string> page;
	[HideInInspector] public int number;
	public int ScriptProgress; //Продвижение по сюжету
	
	//ГЕРОИ 
	public SpriteRenderer IconHeroSprite;
	public InventoryCell[] InvCellHero = new InventoryCell[2];
	
	public int Money=0;			//Деньги игрока
	public int CurrentHero=0;	//Выбранный персонаж

	public bool[] 	HeroIsAlive = new bool[3]; 			//Жив ли герой
	public string[] HeroName = 	new string[3]; 			//Имя героя
	public Sprite[] HeroSprite = new Sprite[3]; 		//Спрайт героя
	public int[] 	HeroLevel = new int[3]; 			//Уровень героя
	public int[] 	HeroCurrentExp = new int[3]; 		//Текущий опыт
	public int[] 	HeroRequiredExp = new int[3];		//Небходимый для повышения уровня опыт
	public float[] 	HeroMaxHp = new float[3];	 		//Максимальное здоровье героя
	public float[] 	HeroMaxMana = new float[3];			//Максимальная мана героя
	public float[] 	HeroManaReg = new float[3];			//Регенерация маны героя
	public float[] 	HeroHpReg = new float[3];			//Регенерация здоровья героя
	public float[] 	HeroVampire = new float[3];			//Вампиризм от физических атак
	public float[] 	HeroDamage = new float[3];			//Урон от физических атак
	public float[] 	HeroAttackCooldown = new float[3];	//Перезарядка физических атак
	public float[] 	HeroMagicPower = new float[3];		//Коэффициент силы заклинаний
	
	public string[] HeroSpellName = new string[9];		//Название способности
	public int[] 	HeroSpellLevel = new int[9];		//Уровень способности
	public string[] HeroSpellInfo = new string[9];		//Описание способности
	public string[] HeroSpellType = new string[9];		//Тип способности
	public float[] 	HeroSpellCost = new float[9];		//Стоимость способности
	public float[]  HeroSpellCooldown = new float[9];	//Время отката способности
	public Sprite[] HeroSpellSprite = new Sprite[9]; 	//Иконка способности
	
	public void DefaultValues()
	{
		HeroIsAlive = new bool[] {true,true,true};
		HeroName = 	new string[] {"Чародей","Алхимик","Мечник"};
		HeroSprite = new Sprite[] {Resources.Load<Sprite>("Sprites/Warlock"),Resources.Load<Sprite>("Sprites/Mechanic"),Resources.Load<Sprite>("Sprites/Warrior")};
		HeroLevel = new int[] {1,1,1};
		HeroCurrentExp = new int[] {0,0,0};
		HeroRequiredExp = new int[] {100,100,100};
		HeroMaxHp = new float[] {75,80,100};
		HeroMaxMana = new float[] {100,90,70};
		HeroManaReg = new float[] {3,2.5f,2};
		HeroHpReg = new float[] {0,0,0};
		HeroVampire = new float[] {0,0,0};
		HeroDamage = new float[] {10,10,20};
		HeroAttackCooldown = new float[] {15,15,15};
		HeroMagicPower = new float[] {10,5,0};
		
		HeroSpellName = new string[] {"Молния","Заморозка","Огонь","Отравление","Исцеление","Огненный шар","Воодушевление","Щит","Исцеление"};
		HeroSpellLevel = new int[] {1,1,1,1,1,1,1,1,1};
		HeroSpellInfo = new string[] {"","","","","","","","",""};
		HeroSpellType = new string[] {"All","Negative","Negative","Negative","Positive","Negative","Positive","Positive","Positive"};
		HeroSpellCost = new float[] {40,20,25,15,25,20,20,30,25};
		HeroSpellCooldown = new float[] {5,5,5,5,5,5,5,5,5};
		HeroSpellSprite = new Sprite[] {
			Resources.Load<Sprite>("Sprites/Icons/thunder"),
			Resources.Load<Sprite>("Sprites/Icons/freeze"),
			Resources.Load<Sprite>("Sprites/Icons/flame"),
			Resources.Load<Sprite>("Sprites/Icons/poison"),
			Resources.Load<Sprite>("Sprites/Icons/heal"),
			Resources.Load<Sprite>("Sprites/Icons/fireball"),
			Resources.Load<Sprite>("Sprites/Icons/inspiration"),
			Resources.Load<Sprite>("Sprites/Icons/shield"),
			Resources.Load<Sprite>("Sprites/Icons/heal"),
		}; 
	}
	
	
	//ГЕРОИ 
	
	//ИНВЕНТАРЬ 
	public ItemManager IManager;
	// 0-7 предметы в рюкзаке
	// 8-9 предметы героя 1
	// 10-11 предметы героя 2
	// 12-14 предметы героя 3
	public bool[] ItemNotEmpty = new bool[14];	//Есть ли предмет в ячейке
	
	public string[] ItemName = new string[14];	//Название предмета
	public string[] ItemInfo = new string[14];	//Описание предмета
	public int   []	ItemCost = new int[14];		//Стоимость предмета
	public Sprite[] ItemSprite = new Sprite[14];//Спрайт предмета
	
	public bool[] ItemActive = new bool[14];	//Есть ли активная способность
	public bool[] ItemPassive = new bool[14];	//Есть ли пассивная способность
	
	public string[] ItemActiveAbility = new string[14];		//Название активной способности
	public string[] ItemPassiveAbility = new string[14];	//Название пассивной способности
	public float [] ItemAbilityCooldown = new float[14];	//Перезарядка активной способности
	public float [] ItemAbilityManaCost = new float[14];	//Стоимость активной способности
	public int []   ItemActiveLevel = new int[14];			//Уровень активной способности
	public int []   ItemPassiveLevel = new int[14];			//Уровень пассивной способности 
	public string []   ItemActiveType = new string[14];		//Тип активной способности
	
	public float[] ItemMaxHp = new float[14];	//Бонус к максимальному здоровью
	public float[] ItemMaxMana = new float[14];	//Бонус к максимальной мане
	public float[] ItemHpReg = new float[14];	//Бонус к восстановлению здоровья
	public float[] ItemManaReg = new float[14];	//Бонус к восстановлению маны
	public float[] ItemCooldown = new float[14];//Бонус к снижению перезарядки способности
	public float[] ItemVampire = new float[14];	//Бонус к вампиризму
	public float[] ItemDamage = new float[14];	//Бонус к урону от физических атак
	public float[] ItemAttackCooldown = new float[14];	//Бонус снижению перезарядки атак
	public float[] ItemMagicPower = new float[14];		//Коэффициент силы заклинаний

	public void ItemDelete (int ind) //Удалить предмет из ячейки инвентаря
	{
		ItemNotEmpty[ind] = false;
		
		ItemName[ind] = "";				ItemCost[ind] = 0;				ItemActive[ind] = false;
		ItemInfo[ind] = "";				ItemSprite[ind] = null;			ItemPassive[ind] = false;		
		ItemActiveAbility[ind] = "";	ItemMaxHp[ind] = 0;				ItemHpReg[ind] = 0;
		ItemPassiveAbility[ind] = "";	ItemMaxMana[ind] = 0;			ItemManaReg[ind] = 0;		
		ItemCooldown[ind] = 0;			ItemVampire[ind] = 0;			ItemDamage[ind] = 0;
		ItemAbilityCooldown[ind] = 0;	ItemAbilityManaCost[ind] = 0;   ItemAttackCooldown[ind] = 0;
		ItemMagicPower[ind] = 0;		ItemActiveLevel[ind] = 0;		ItemPassiveLevel[ind] = 0;
		ItemActiveType[ind] = "";
	}
	
	public bool InventoryIsFull() //Если инвентарь полон
	{
		bool b=false;
		for (int i=0; i<14; i++)
		{
			if (!ItemNotEmpty[i]) {break;} else
				{if (i==13) {b=true;}}
		}
		return b;
	}
	
	public void ItemSwap (int ind1, int ind2) //Поменять два предмета местами
	{
		if ((ItemNotEmpty[ind1])||(ItemNotEmpty[ind2]))
		{
			//Временные переменные для замены
			bool  _ItemNotEmpty = ItemNotEmpty[ind2];
			string _ItemName = ItemName[ind2];							int  _ItemCost = ItemCost[ind2];							bool  _ItemActive = ItemActive[ind2];
			string _ItemInfo = ItemInfo[ind2];							Sprite _ItemSprite = ItemSprite[ind2];						bool  _ItemPassive = ItemPassive[ind2];
			string _ItemActiveAbility = ItemActiveAbility[ind2];		float  _ItemMaxHp = ItemMaxHp[ind2];						float _ItemHpReg = ItemHpReg[ind2];
			string _ItemPassiveAbility = ItemPassiveAbility[ind2];		float  _ItemMaxMana = ItemMaxMana[ind2];					float _ItemManaReg = ItemManaReg[ind2];
			float  _ItemCooldown = ItemCooldown[ind2];					float  _ItemVampire = ItemVampire[ind2];					float _ItemDamage = ItemDamage[ind2];
			float  _ItemAbilityCooldown = ItemAbilityCooldown[ind2];	float  _ItemAbilityManaCost = ItemAbilityManaCost[ind2];	float _ItemAttackCooldown = ItemAttackCooldown[ind2];
			float  _ItemMagicPower = ItemMagicPower[ind2];				int    _ItemActiveLevel = ItemActiveLevel[ind2];			int   _ItemPassiveLevel = ItemPassiveLevel[ind2];
			string _ItemActiveType = ItemActiveType[ind2];
			
			if (ind2>7) {ItemRemoveStates(ind2);}
			
			ItemNotEmpty[ind2] = ItemNotEmpty[ind1];
			ItemName[ind2] = ItemName[ind1];						ItemCost[ind2] = ItemCost[ind1];						ItemActive[ind2] = ItemActive[ind1];
			ItemInfo[ind2] = ItemInfo[ind1];						ItemSprite[ind2] = ItemSprite[ind1];					ItemPassive[ind2] = ItemPassive[ind1];		
			ItemActiveAbility[ind2] = ItemActiveAbility[ind1];		ItemMaxHp[ind2] = ItemMaxHp[ind1];						ItemHpReg[ind2] = ItemHpReg[ind1];
			ItemPassiveAbility[ind2] = ItemPassiveAbility[ind1];	ItemMaxMana[ind2] = ItemMaxMana[ind1];					ItemManaReg[ind2] = ItemManaReg[ind1];		
			ItemCooldown[ind2] = ItemCooldown[ind1];				ItemVampire[ind2] = ItemVampire[ind1];					ItemDamage[ind2] = ItemDamage[ind1];
			ItemAbilityCooldown[ind2] = ItemAbilityCooldown[ind1];	ItemAbilityManaCost[ind2] = ItemAbilityManaCost[ind1];	ItemAttackCooldown[ind2] = ItemAttackCooldown[ind1];
			ItemMagicPower[ind2] = ItemMagicPower[ind1];			ItemActiveLevel[ind2] = ItemActiveLevel[ind1];			ItemPassiveLevel[ind2] = ItemPassiveLevel[ind1];
			ItemActiveType[ind2] = ItemActiveType[ind1];
			
			if (ind2>7) {ItemTakeStates(ind2);}
			if (ind1>7) {ItemRemoveStates(ind1);}
			
			ItemNotEmpty[ind1] = _ItemNotEmpty;
			ItemName[ind1] = _ItemName;								ItemCost[ind1] = _ItemCost;								ItemActive[ind1] = _ItemActive;
			ItemInfo[ind1] = _ItemInfo;								ItemSprite[ind1] = _ItemSprite;							ItemPassive[ind1] = _ItemPassive;		
			ItemActiveAbility[ind1] = _ItemActiveAbility;			ItemMaxHp[ind1] = _ItemMaxHp;							ItemHpReg[ind1] = _ItemHpReg;
			ItemPassiveAbility[ind1] = _ItemPassiveAbility;			ItemMaxMana[ind1] = _ItemMaxMana;						ItemManaReg[ind1] = _ItemManaReg;		
			ItemCooldown[ind1] = _ItemCooldown;						ItemVampire[ind1] = _ItemVampire;						ItemDamage[ind1] = _ItemDamage;
			ItemAbilityCooldown[ind1] = _ItemAbilityCooldown;		ItemAbilityManaCost[ind1] = _ItemAbilityManaCost;		ItemAttackCooldown[ind1] = _ItemAttackCooldown;
			ItemMagicPower[ind1] = _ItemMagicPower;					ItemActiveLevel[ind1] = _ItemActiveLevel;				ItemPassiveLevel[ind1] = _ItemPassiveLevel;
			ItemActiveType[ind1] = _ItemActiveType;
			
			if (ind1>7) {ItemTakeStates(ind1);}
			
		}
	}
	
	public void ItemTakeStates(int ind) //Передать свойства предмета персонажу
	{
		if ((ind>7)&&(ind<14))
		{
			int n = (ind-8)/2;
			HeroMaxHp[n] += ItemMaxHp[ind];	 		//Максимальное здоровье героя
			HeroMaxMana[n] += ItemMaxMana[ind];			//Максимальная мана героя
			HeroManaReg[n] += ItemManaReg[ind];			//Регенерация маны героя
			HeroHpReg[n] += ItemHpReg[ind];			//Регенерация здоровья героя
			HeroVampire[n] += ItemVampire[ind];			//Вампиризм от физических атак
			HeroDamage[n] += ItemDamage[ind];			//Урон от физических атак
			HeroAttackCooldown[n] += ItemAttackCooldown[ind];	//Перезарядка физических атак
			HeroMagicPower[n] += ItemMagicPower[ind];		//Коэффициент силы заклинаний
		}
	}
	
	public void ItemRemoveStates(int ind) //Забрать свойства предмета у персонажа
	{
		if ((ind>7)&&(ind<14))
		{
			int n = (ind-8)/2;
			HeroMaxHp[n] -= ItemMaxHp[ind];	 		//Максимальное здоровье героя
			HeroMaxMana[n] -= ItemMaxMana[ind];			//Максимальная мана героя
			HeroManaReg[n] -= ItemManaReg[ind];			//Регенерация маны героя
			HeroHpReg[n] -= ItemHpReg[ind];			//Регенерация здоровья героя
			HeroVampire[n] -= ItemVampire[ind];			//Вампиризм от физических атак
			HeroDamage[n] -= ItemDamage[ind];			//Урон от физических атак
			HeroAttackCooldown[n] -= ItemAttackCooldown[ind];	//Перезарядка физических атак
			HeroMagicPower[n] -= ItemMagicPower[ind];		//Коэффициент силы заклинаний
		}
	}
	
	public void ItemSell(int ind) //Продать предмет
	{
		if (ItemNotEmpty[ind])
		{
			Money+=ItemCost[ind];
			ItemDelete(ind);
		}
	}
	void ItemBuy(Item item) //Купить предмет
	{
		if (!InventoryIsFull())
		{
			if (Money>=item.Cost)
			{
				Money-=item.Cost;
				item.ToInventory();
			}
		}
	}
	void ItemAdd(Item item) //Добавить предмет в инвентарь
	{
		if (!InventoryIsFull())
		{
			item.ToInventory();
		}
	}
	
	//ИНВЕНТАРЬ 
	
	[HideInInspector] public bool AfterFight=false; //Флаг, для выполнения действий после выхода из боевой сцены
	public int DialogueBranch=-1; //Ветвь диалога (если не выбрана, то -1)
	
	//Это для восстановления кнопок, после возвращения из боевой сцены
	[HideInInspector] public List<System.Tuple<Vector2, int, string,string, bool>> ToSceneList = new List<System.Tuple<Vector2, int, string,string, bool>>(); //ToSceneList.Add(Vector2, Page, Text, SceneName, Destroying);
	
	//Максимум один диалог
	[HideInInspector] public List<System.Tuple<Vector2, int, string, int>> DBranches = new List<System.Tuple<Vector2, int, string, int>>(); //DBranches.Add(Vector2, Page, Text, Num);
	[HideInInspector] public bool DialogExtraPage = false;
	
	public void ReloadButtons() //Воссоздание кнопок перехода после возвращения из боевой сцены
	{
		int count = ToSceneList.Count;
		for (int i = 0; i<count; i++)
		{
			var inst = Instantiate(TextToScene,ToSceneList[0].Item1, transform.rotation);
			inst.transform.SetParent(Canvas.transform);
			var inst2 = inst.GetComponent<TextToScene>();
			inst2.page=ToSceneList[0].Item2;
			inst2.text=ToSceneList[0].Item3;
			inst2.scene_name=ToSceneList[0].Item4;
			inst2.destroying=ToSceneList[0].Item5;
			ToSceneList.RemoveAt(0);
		}
		count = DBranches.Count;
		if (count!=0)
		{
			var dia = Instantiate(DialogPref,transform.position, transform.rotation);
			dia.transform.SetParent(Canvas.transform);
			var dia2 = dia.GetComponent<Dialog>();
			dia2.ExtraPage=DialogExtraPage;
			for (int i = 0; i<count; i++)
			{
				var branch = Instantiate(BranchPref,DBranches[0].Item1,transform.rotation);
				branch.transform.SetParent(dia.transform);
				var branch2 = branch.GetComponent<DBranch>();
				branch2.page=DBranches[0].Item2;
				branch2.text=DBranches[0].Item3;
				branch2.num=DBranches[0].Item4;
				branch2.dialog=dia2;
				DBranches.RemoveAt(0);
			}
		}
	}
	//
	
	void CreateText(string t, bool Storyline) //Создать текст
	{
		var creator = (Instantiate(TCreator, transform.position, transform.rotation)).GetComponent<TextCreator>();
		creator.text=t;
		creator.Storyline=Storyline; //Является ли текст сюжетной линией (или это случаное событие)
	}
	
	Dialog StartDialog() //Начать диалог
	{
		var dia = (Instantiate(DialogPref, transform.position, transform.rotation)).GetComponent<Dialog>();
		dia.transform.SetParent(Canvas.transform);
		return dia;
	}
	
	void AddLink(GameObject pref) //Сюжетный переход на следующую страницу (при смене главы, например)
	{
		TextMesh2.text=page[page.Count-1]+"\n[Читать далее]";
		TextMesh2.ForceMeshUpdate();
		if (TextMesh2.firstOverflowCharacterIndex!=-1)
		{
			page.Add("");
		}
		else
		{
			page[page.Count-1]+="\n";
		}
		TextMesh2.text=page[page.Count-1];
		TextMesh2.ForceMeshUpdate();
		Vector2 vec = new Vector2(Text.transform.position.x, Text.transform.position.y-TextMesh2.GetRenderedValues()[1]);
		var inst = Instantiate(pref, vec, transform.rotation);
		inst.transform.SetParent(Canvas.transform);
	}
	
	void ToScene(string t,string scene_name, bool destroying) //Кнопка перехода на боевую сцену
	{
		TextMesh2.text=page[page.Count-1]+'\n'+t;
		TextMesh2.ForceMeshUpdate();
		if (TextMesh2.firstOverflowCharacterIndex!=-1)
		{
			page.Add("");
		}
		else
		{
			page[page.Count-1]+="\n";
		}
		TextMesh2.text=page[page.Count-1];
		TextMesh2.ForceMeshUpdate();
		Vector2 vec = new Vector2(Text.transform.position.x, Text.transform.position.y-TextMesh2.GetRenderedValues()[1]);
		page[page.Count-1]+=t+'\n';
		var inst = Instantiate(TextToScene,vec, transform.rotation);
		inst.transform.SetParent(Canvas.transform);
		var inst2 = inst.GetComponent<TextToScene>();
		inst2.page=page.Count-1;
		inst2.text=t;
		inst2.scene_name=scene_name;
		inst2.destroying=destroying;
	}
	
	void ChangePage() //Смена страницы с клавиатуры
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (number>0)
				number--;
        }
		if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (number<page.Count-1) 
				number++;
        }
	}
	
	public void Awake()
    {
        if (FindObjectsOfType(GetType()).Length == 1)
		{
			DontDestroyOnLoad(gameObject);
			DefaultValues();
		}
		else
		{
			Destroy(gameObject);
		}
    }
	
	public void CellCreate()
	{
		for (int i=0; i<2; i++)
		{
			Vector2 vec = new Vector2(3.4f+0.85f*i,-0.8f);
			var Cell = (Instantiate(InvCellPref, vec, transform.rotation)).GetComponent<InventoryCell>();
			Cell.index = 8+i+CurrentHero*2;
			Cell.controller = this;
			InvCellHero[i] = Cell;
			
			Instantiate(CellSpritePref, vec, transform.rotation);
			for (int j=0; j<4; j++)
			{
				vec = new Vector2(1.7f+0.85f*j,-2.32f-0.85f*i);
				Cell = (Instantiate(InvCellPref, vec, transform.rotation)).GetComponent<InventoryCell>();
				Cell.index = j+i*4;
				Cell.controller = this;
				Instantiate(CellSpritePref, vec, transform.rotation);
			}				
		}
	}
	
    void Start()
    {
		page.Add("");
		number=0;
		ScriptProgress=0;
		CreateText("ОТ АВТОРА \n\nПриветствую вас, дорогие читатели. Мое имя - <b>Акылбек</b>, и в этой книге я поведаю вам одну любопытную историю, которая произошла со мной, но отразилась на многих из вас да и вообще на всем, что есть в этом прекрасном мире.\n\nНаверняка вы читаете сие творение, находясь в своем уютном гномьем логове, даже не подозревая, что это логово осталось уютным благодаря мне и событиям далекого 228 года Эльфийской Эры...",true);
		CellCreate();
		IManager.ItemCreate("PoisonBottle").ToInventory();
		IManager.ItemCreate("MagicAmulet").ToInventory();
		IManager.ItemCreate("DragonCane").ToInventory();
	}
	
	void Update()
	{
		if (Text!=null)
		{
			TextMesh.text=page[number];
			if (PageNumber!=null)
			{
				PageNumberText.text=(number+1)+"/"+page.Count;
			}
			if (AfterFight)
			{
				ReloadButtons();
				CellCreate();
				AfterFight=false;
			}
			ChangePage();
			switch (ScriptProgress)//Сюжет
			{
				case 1:
					ScriptProgress++;
					AddLink(NextPage);
				break;
				case 3:
					ScriptProgress++;
					CreateText("ПРОЛОГ\n\nВ тот год <color=\"red\">Великое Зло<color=\"black\"> достигло пика своего могущества и угрожало существованию нашего славного эльфийского рода. Из подземелий выбирались демонические создания и крушили все на своем пути. Эльфы страдали от набегов темных существ, а легендарный Лес Жизни превратился в самое опасное место во всем Эльфийском Царстве. Тогда и пошла в народе молва, что остановить Зло можно лишь спустившись в Подземелья Хаоса и уничтожив верховного демона Ержана. Много смельчаков полегло в этих подземельях. И вот настал мой черед спуститься туда вместе с верными друзьями Джонни и Олегом, дабы попытать удачу и по возможности <s>собрать лукошко магических грибов</s> остановить Великое Зло. Так мы оказались\n<b>ПОГРУЖЕННЫМИ ВО ТЬМУ</b> \n\nГлава 1. Приключения начинаются \n\nЗная об опасности подземелий, мы решили для начала",true);
				break;
				case 5:
					ScriptProgress++;
					ToScene("Пройти обучение","Training",true);
				break;
				case 7:
					ScriptProgress++;
					IManager.ItemCreate("IceCrystal").ToInventory();
					CreateText("Только после этого мы зашли внутрь, где сразу же наткнулись на стадо диких туннельных кабанов, которые",true);
				break;
				case 9:
					ScriptProgress++;
					ToScene("Приветливо нас встретили","Training",true);
				break;
				case 11:
					ScriptProgress++;
					CreateText("Разделавшись с ними, наш отряд пошел дальше. Впереди была развилка с указателями: \"Налево - Темные эльфы\", \"Направо - Гоблины\" мы повернули",true);
				break;
				case 13:
					ScriptProgress++;
					var dia = StartDialog();
					dia.AddBranch("-Налево");
					dia.AddBranch("-Направо");
				break;
				case 14:
					if (DialogueBranch==0)
					{
						ScriptProgress++;
						CreateText(" налево... Там нас и поджидали эльфы, настроенные весьма агрессивно",true);
					}
					if (DialogueBranch==1)
					{
						ScriptProgress++;	
						CreateText(" направо, где в самом деле располагалось логово гоблинов",true);
					}
				break;
				case 16:
					ScriptProgress++;
					ToScene("Произошла небольшая стычка","Training",true);
				break;
				case 18:
					ScriptProgress++;
					CreateText("Местное население оказалось не очень дружелюбным, но тем не менее мы получили от них полезный предмет. Дорога привела нас широкому проходу, который, к сожалению, оказался заблокирован огромным существом, по всей видимости - примитивным огром. Обойти не получится, придется",true);
				break;
				case 20:
					ScriptProgress++;
					ToScene("Вступить в бой","Training",true);
				break;
				case 22:
					ScriptProgress++;
					CreateText("Применив недюжинную смекалку, мы одолели неприятеля. Перед нами открылись поистине огромные лабиринты Подземелий Хаоса.",true);
				break;
				case 24:
					ScriptProgress++;
					ToScene("Поблуждав немного без цели","Training",false);
					CreateText("Мы нашли лестницу и решили по ней спуститься...\n<b>Конец Первой Главы</b>",true);
				break;
				case 26:
					ScriptProgress++;
					AddLink(NextPage);
				break;
			}
		}
	}
}