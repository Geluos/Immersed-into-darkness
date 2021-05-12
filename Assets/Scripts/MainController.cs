using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class ListGameObj
{
    public List<GameObject> list;
}

[System.Serializable]
public class ListListGameObj
{
    public List<ListGameObj> list;
}

[System.Serializable]
public class MainController : MonoBehaviour
{

    //Изначально 
    public GameObject FirstPage;


    public GameObject BattlePage;

    //Пока публичный для просмотра
    public List<GameObject> Pages;

    public ListListGameObj PagesForStages;

    public int stage;
    //-1 - Хаб
    //0 - Начальный текст

    public Friends SwordmanP;
    public Friends AlchemistP;
    public Friends DocP;
    public Friends RifflewomanP;

    public List<Friends> friends;

    public bool godmode = false;

    public List<string> MusicForStages;

    [HideInInspector] public Sprite Background;
    [HideInInspector] public List<GameObject> Lights;
    [HideInInspector] public List<Enemies> EnemyList;

    [HideInInspector] public string[] names;

    public GameObject InfoBarPref; //Префаб всплывающего окна с информацией
    [HideInInspector] public GameObject infoBar; //Текущее окно с информацией

    void Start()
    {
        stage = -1;
        PlayMusic("Nikfus - Tragedy");
    }


    public void Awake()
    {
        if (FindObjectsOfType(GetType()).Length == 1)
		{
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
    }
    IEnumerator EndB()
    {
        yield return new WaitForSeconds(3f);
        GameObject.FindWithTag("FightController").GetComponent<FightController>().CopyHeroesToMain();
        SceneManager.LoadScene("StoryScene");
        foreach(GameObject pg in Pages)
        {
            pg.SetActive(false);
        }
        Pages.Add(Instantiate(BattlePage, transform));
        PlayMusic(MusicForStages[stage]);
    }
    public void EndBattle()
    {
        StartCoroutine(EndB());
    }

    public void toPage(GameObject pg)
    {
        Pages[Pages.Count-1].SetActive(false);
        Pages.Add(Instantiate(pg, transform));
        Pages[Pages.Count-1].SetActive(true);
    }

    public void UnActiveLastPage()
    {
        Pages[Pages.Count-1].SetActive(false);
    }

    public void PlayMusic(string name)
    {
        print("Музука");
        gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(name);
        gameObject.GetComponent<AudioSource>().Play();
    }


    public void StopMusic()
    {
        
        print("No musuca");
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public void NextStage()
    {
        if(Pages.Count - 1>0)
            Pages[Pages.Count - 1].SetActive(false);
        ++stage;
        if (stage == 0)
        {
            //PlayMusic(MusicForStages[stage]);
        }
        if (stage>0 && MusicForStages[stage-1] != MusicForStages[stage])
            PlayMusic(MusicForStages[stage]);
        var rand = new System.Random();
        int index = rand.Next(PagesForStages.list[stage].list.Count-1);
        Pages.Add(Instantiate(PagesForStages.list[stage].list[index], transform));
        Pages[Pages.Count - 1].SetActive(true);
    }

    public void ToFightScene()
    {
        SceneManager.LoadScene("FightScene");
        //FightController FightControl = GameObject.FindGameObjectWithTag("FightController").GetComponent<FightController>();
    }

    public void Do()
    {
        //Временное решение?
        switch (stage) {
            case -1:
                break;
            case 0:
                CreateHeroes();
                Pages.Add(Instantiate(FirstPage, transform));
                //Активируем первую страницу
                Pages[1].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void CreateHeroes()
    {
        for (int i = 0; i < 3; ++i)
        {
            switch (names[i])
            {
                case "swordsman":
                    friends.Add(Instantiate(SwordmanP, transform).GetComponent<Warrior>());
                    break;
                case "doctor":
                    friends.Add(Instantiate(DocP, transform).GetComponent<Warrior>());
                    break;
                case "alchemist":
                    friends.Add(Instantiate(AlchemistP, transform).GetComponent<Warrior>());
                    break;
                case "rifflewoman":
                    friends.Add(Instantiate(RifflewomanP, transform).GetComponent<Warrior>());
                    break;
            }
            friends[i].gameObject.SetActive(false);
        }
    }
}
