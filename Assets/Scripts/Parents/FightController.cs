using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class FightController : MonoBehaviour
{
	[HideInInspector] public bool select_friend;
	[HideInInspector] public bool select_enemy;
	
	public GameObject background;
	public List<Friends> friends;
	public List<Enemies> enemies = new List<Enemies>();
	public GameObject[] EnemyPref = new GameObject[1];//UPDATE
	public Spells spell;
	[HideInInspector] public Friends UseFriend;
	[HideInInspector] public Friends TargetFriend;
	[HideInInspector] public Enemies TargetEnemy;
	public Friends CurrentUnit;
	public GameObject restart;
	public GameObject SelectFriend;
	public GameObject SelectEnemy;
	[HideInInspector] public bool res = false;
	[HideInInspector] public int resEn = 0;
	[HideInInspector] public float timeResEn = 0;
	[HideInInspector] public float startTimeResEn = 3;
	public GameObject[] pos = new GameObject[3];
	public GameObject[] posEn = new GameObject[3];
	
	public TextMeshProUGUI textTimeRes;

	public AudioSource music1;
	public AudioSource music2;

	private GameObject tacticalPause;
	private bool isPause = false;

	private void Pause()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
			if (!isPause)
            {
				Time.timeScale = 0f;
				isPause = true;
				tacticalPause.SetActive(true);
            }
			else
            {
				Time.timeScale = 1f;
				isPause = false;
				tacticalPause.SetActive(false);
			}
        }
    }
    void Start()
    {
		tacticalPause = Instantiate(Resources.Load<GameObject>("tacticalPause"), transform);
		tacticalPause.SetActive(false);
		var GC = GameObject.FindWithTag("GameController").GetComponent<MainController>();
		foreach (var enemy in GC.EnemyList)
		{
			Instantiate(enemy);
		}

		foreach (var light in GC.Lights)
		{
			Instantiate(light);
		}

		background.GetComponent<SpriteRenderer>().sprite = GC.Background;

		//Здесь была отрисовка иконок
		StartCoroutine(PlayMusic());
		StartCoroutine(SortHeroes()); 
    }

	IEnumerator SortHeroes()
    {
		yield return new WaitForFixedUpdate();
		//Чтобы бой не заканчивался в начале
		finish = false;
		Friends TempF;
		if(friends[0].NumInList!=0)
        {
			TempF = friends[0];
			friends[0] = friends[1];
			friends[1] = TempF;
			if (friends[0].NumInList != 0)
            {
				TempF = friends[0];
				friends[0] = friends[2];
				friends[2] = TempF;
			}
		}

		if (friends[1].NumInList != 1)
        {
			TempF = friends[1];
			friends[1] = friends[2];
			friends[2] = TempF;
		}

		CopyHeroesFromMain();
		print("копирование способностей прошло успешно");
	}

	public void CopyHeroesFromMain()
    {
		//копирование героев из контроллера на боевую сцену
		var GC = GameObject.FindWithTag("GameController").GetComponent<MainController>();
		for (int i = 0; i < 3; ++i)
		{
			//friends[i] = GC.friends[i];

			friends[i].Name = GC.friends[i].Name;
			friends[i].hp = GC.friends[i].hp;
			friends[i].maxhp = GC.friends[i].maxhp;
			friends[i].defenceMultiply = GC.friends[i].defenceMultiply;
			friends[i].power = GC.friends[i].power;
			friends[i].HpRegen = GC.friends[i].HpRegen;
			friends[i].CooldownReduction = GC.friends[i].CooldownReduction;
			friends[i].CurrentExp = GC.friends[i].CurrentExp;
			friends[i].RequiredExp = GC.friends[i].RequiredExp;
			friends[i].Level = GC.friends[i].Level;
			for (int j = 0; j < 3; ++j)
			{
				friends[i].Spells[j] = GC.friends[i].Spells[j];
				friends[i].SpellLevel[j] = GC.friends[i].SpellLevel[j];
			}
			friends[i].alive = GC.friends[i].alive;
			friends[i].gameObject.GetComponent<SpriteRenderer>().sprite = GC.friends[i].gameObject.GetComponent<SpriteRenderer>().sprite;
			if (!friends[i].alive)
			{
				friends[i].spriteRend.sprite = null;
			}
			else
            {
				friends[i].Initialize();
			}
		}
	}

	public void CopyHeroesToMain()
    {
		var GC = GameObject.FindWithTag("GameController").GetComponent<MainController>();
		for (int i = 0; i < 3; ++i)
		{
			GC.friends[i].hp = friends[i].hp;
			GC.friends[i].alive = friends[i].alive;
		}
	}

	IEnumerator PlayMusic()
	{
		yield return new WaitForSeconds(1);
		/*
		music1.Play();
		//yield return new WaitForSeconds(6.0857f);
		yield return new WaitForSeconds(music1.clip.length);
		music2.Play();*/
	}

	void ChangeCurrentUnit()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && Time.timeScale != 0f)
		{
			if (CurrentUnit==null)
			{
				CurrentUnit = friends[0];
				CurrentUnit.ActiveHero();
				friends[0].DestroyHalo(friends[0].halo);
				friends[0].halo = friends[0].CreateHalo(Color.yellow);
			}
			else
			{
				CurrentUnit.DestroyHalo(CurrentUnit.halo);
				do
				{
					CurrentUnit = friends[(friends.IndexOf(CurrentUnit) + 1) % 3];
				}
				while (CurrentUnit.alive == false);
				CurrentUnit.ActiveHero();
				CurrentUnit.DestroyHalo(CurrentUnit.halo);
				CurrentUnit.halo = CurrentUnit.CreateHalo(Color.yellow);
			}
			SelectFriend.SetActive(false);
			SelectEnemy.SetActive(false);
			select_friend=false;
			select_enemy=false;
			print("Выбран " + CurrentUnit.gameObject.name);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if(CurrentUnit!=null)
            {
				CurrentUnit.DestroyHalo(CurrentUnit.halo);
			}
			

			CurrentUnit = friends[0];

			CurrentUnit.DestroyHalo(CurrentUnit.halo);
			CurrentUnit.halo = CurrentUnit.CreateHalo(Color.yellow);

			CurrentUnit.ActiveHero();
			SelectFriend.SetActive(false);
			SelectEnemy.SetActive(false);
			select_friend=false;
			select_enemy=false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if (CurrentUnit != null)
			{
				CurrentUnit.DestroyHalo(CurrentUnit.halo);
			}


			CurrentUnit = friends[1];

			CurrentUnit.DestroyHalo(CurrentUnit.halo);
			CurrentUnit.halo = CurrentUnit.CreateHalo(Color.yellow);

			CurrentUnit.ActiveHero();
			SelectFriend.SetActive(false);
			SelectEnemy.SetActive(false);
			select_friend=false;
			select_enemy=false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (CurrentUnit != null)
			{
				CurrentUnit.DestroyHalo(CurrentUnit.halo);
			}


			CurrentUnit = friends[2];

			CurrentUnit.DestroyHalo(CurrentUnit.halo);
			CurrentUnit.halo = CurrentUnit.CreateHalo(Color.yellow);

			CurrentUnit.ActiveHero();
			SelectFriend.SetActive(false);
			SelectEnemy.SetActive(false);
			select_friend=false;
			select_enemy=false;
		}
	}

	public int AliveHeroes()
	{
		int res = 0;
		foreach(Friends fr in friends)
		{
			if(fr.alive)
				res++;
		}
		//print("Кол-во живых героев" + res);
		return res;
	}

	bool finish = true;
    private void Update()
    {
		Pause();
		if (AliveHeroes() == 0)
        {
			//Поражение
        }

		if(enemies.Count == 0 && !finish)
        {
			finish = true;
			GameObject.FindWithTag("GameController").GetComponent<MainController>().EndBattle();
		}
		
		if (AliveHeroes() == 0)
		{
			restart.SetActive(true);
			//Снятие эффектов у врагов
		}
		else
		{
			ChangeCurrentUnit();
		}
		if (select_friend||select_enemy) //Если применяется способность, обладатель которой уже мертв
        {
			if (!spell.HeroCharacter.alive)
            {
				select_friend = false;
				select_enemy = false;
				spell = null;
				SelectFriend.SetActive(false);
				SelectEnemy.SetActive(false);
				TargetFriend = null;
				TargetEnemy = null;
			}
        }
		/*
		if (res)
		{
			restart.SetActive(false);
			//UPDATE
            for (int i = 0; i <= enemies.Count-1; i++)
            {
				enemies[i].hp = enemies[i].maxhp;
				enemies[i].Combat = true;
            }
			//UPDATE
			res = false;
		}
		if ((enemies.Count == 0) & (resEn == 0))
        {
            resEn = 1;
            timeResEn = startTimeResEn;
        }
        timeResEn -= Time.deltaTime;
        if (timeResEn>0)
        { textTimeRes.text = Mathf.Ceil(timeResEn).ToString(); } else { textTimeRes.text = ' '.ToString(); }
        if ((resEn == 1) & (timeResEn <= 0))
        {
			//UPDATE
			int r = Random.Range(1,4);
            for (int i = 0; i <r ; i++)
            {
				var enemy = Instantiate(EnemyPref[Random.Range(0,EnemyPref.Length)], posEn[i].transform.position, transform.rotation) as GameObject;
				enemy.GetComponent<Enemies>().fightController=this;
            }
            resEn = 0;
			//UPDATE
        }*/
	}


    public void SpellUseTarget()
	{
		
		if (select_friend) 
		{
			if (TargetFriend!=null)
			{
				StartCoroutine(spell.HeroCharacter.AtakeAnim());
				spell.Use(TargetFriend);
				//!
				//UseFriend.reloadTime=UseFriend.spell_cooldown[spell_num];
				select_friend=false;
				SelectFriend.SetActive(false);
				TargetFriend=null;
				//!Отрисовать затемнение на иконках способностей
				/*for(int i=0; i<3; ++i)
					UseFriend.CreateSpellReload(i,UseFriend.spell_cooldown[spell_num]);*/
			}
		}				
		else
		if (select_enemy)
		{
			if (TargetEnemy!=null)
			{
				StartCoroutine(spell.HeroCharacter.AtakeAnim());
				print("ABBA");
				spell.Use(TargetEnemy);
				//!
				//UseFriend.reloadTime=UseFriend.spell_cooldown[spell_num];
				select_enemy=false;
				SelectEnemy.SetActive(false);
				TargetEnemy=null;
				//!Отрисовать затемнение на иконках способностей
				/*for(int i=0; i<3; ++i)
					UseFriend.CreateSpellReload(i,UseFriend.spell_cooldown[spell_num]);*/
			}
		}
	}

	public void SpellUseAll()
	{
		spell.Use();
		//character.SetReload(spell.reloadtime);
		//Затемнение иконок способностей
	}

	
}
