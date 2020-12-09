using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightController : MonoBehaviour
{
	[HideInInspector] public bool select_friend;
	[HideInInspector] public bool select_enemy;
	
	public List<Friends> friends;
	[HideInInspector] public List<Friends> friends2;
	public List<Enemies> enemies;
	
	public GameObject IconPref;
	public Transform[] IconPos = new Transform[3];
	
	[HideInInspector] public GameObject[] Icon = new GameObject[3];
	[HideInInspector] public IconSpell[] icon = new IconSpell[3];
	public GameObject[] EnemyPref = new GameObject[1];//UPDATE
	
	[HideInInspector] public int spell_num;
	[HideInInspector] public Spells spell;
	[HideInInspector] public Friends UseFriend;
	[HideInInspector] public Friends TargetFriend;
	[HideInInspector] public Enemies TargetEnemy;
	[HideInInspector] public Friends CurrentUnit;
	
	public GameObject SpellReloadPref;
	public GameObject EnemyHealthBarPref;
	public GameObject CanvasObject;
	public IconHero IconHero;
	[HideInInspector] public Transform Canvas;
	
	[HideInInspector] public HealthBar health;
	[HideInInspector] public ManaBar mana;
	
	public GameObject healthBar;
	public GameObject manaBar;

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
	[HideInInspector] public int CurrentUnitNum = -1;

	public AudioSource music1;
	public AudioSource music2;

    void Start()
    {
		Canvas=CanvasObject.transform;
		for (int i=0; i<=2; i+=1)
		{
			Icon[i] = (GameObject)Instantiate(IconPref, IconPos[i].position, transform.rotation) as GameObject;
			icon[i] = Icon[i].GetComponent<IconSpell>();
			icon[i].fight = this; 
			icon[i].num = i;
		}
		StartCoroutine(PlayMusic());
    }

	IEnumerator PlayMusic()
	{
		yield return new WaitForSeconds(1);
		music1.Play();
		//yield return new WaitForSeconds(6.0857f);
		yield return new WaitForSeconds(music1.clip.length);
		music2.Play();
	}

		void ChangeCurrentUnit()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (CurrentUnit==null)
			{
				friends[0].GetSpells();
				CurrentUnitNum=0;
			}
			else
			{
				CurrentUnitNum++;
				if (CurrentUnitNum>=friends.Count) {CurrentUnitNum=0;}
				friends[CurrentUnitNum].GetSpells();
			}
			SelectFriend.SetActive(false);
			SelectEnemy.SetActive(false);
			select_friend=false;
			select_enemy=false;
		}
	}
	
    private void Update()
    {
		if (friends.Count == 0)
		{
			restart.SetActive(true);
			for (int i = 0; i <= enemies.Count-1; i++)
            {
				//UPDATE
				if (enemies[i].PoisonParticle!=null)
				{
					Destroy(enemies[i].PoisonParticle,5);
					enemies[i].PoisonParticle.GetComponent<ParticleSystem>().Stop();
					enemies[i].PoisonParticle=null;
				}
				if (enemies[i].FreezeParticle!=null)
				{
					Destroy(enemies[i].FreezeParticle,5);
					enemies[i].FreezeParticle.GetComponent<ParticleSystem>().Stop();
					enemies[i].FreezeParticle=null;
				}
				//UPDATE
				enemies[i].IsFreezing=false;
				enemies[i].PoisonDamage=0;
				if (enemies[i].EfIce!=null) {Destroy(enemies[i].EfIce.gameObject);}
				if (enemies[i].EfFlame!=null) {Destroy(enemies[i].EfFlame.gameObject);}
				enemies[i].sprite.color = new Color (1f, 1f, 1f, 1f);
			}
		}
		else
		{
			ChangeCurrentUnit();
		}
		if (res)
		{
			restart.SetActive(false);
            for (int i = 0; i <= friends2.Count-1; i++)
            {
				friends.Add(friends2[i]);
				friends2[i].transform.position = pos[i].transform.position;
            }
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
				enemy.GetComponent<Enemies>().fight=this;
            }
            resEn = 0;
			//UPDATE
        }
	
		if(Input.GetKey("escape"))
		{
			Application.LoadLevel("Menu");
		}
	}
	
	public void SpellUseTarget()
	{
		if (select_friend) 
		{
			if (TargetFriend!=null)
			{
				spell.SpellUseTarget(TargetFriend);
				UseFriend.spell_timeout[spell_num]=UseFriend.spell_cooldown[spell_num];
				UseFriend.mana-=UseFriend.spell_cost[spell_num];
				select_friend=false;
				SelectFriend.SetActive(false);
				TargetFriend=null;
				UseFriend.CreateSpellReload(spell_num,UseFriend.spell_cooldown[spell_num]);
			}
		}				
		else
		if (select_enemy)
		{
			if (TargetEnemy!=null)
			{
				spell.SpellUseTarget(TargetEnemy);
				UseFriend.spell_timeout[spell_num]=UseFriend.spell_cooldown[spell_num];
				UseFriend.mana-=UseFriend.spell_cost[spell_num];
				select_enemy=false;
				SelectEnemy.SetActive(false);
				TargetEnemy=null;
				UseFriend.CreateSpellReload(spell_num,UseFriend.spell_cooldown[spell_num]);
			}
		}
	}
}
