using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainController : MonoBehaviour
{

    //Изначально 
    public GameObject FirstPage;

    public GameObject BattlePage;

    //Пока публичный для просмотра
    public List<GameObject> Pages;

    public int stage;
    //1 - Хаб
    //2 - Начальный текст

    public Friends SwordmanP;
    public Friends AlchemistP;
    public Friends DocP;
    public Friends RifflewomanP;

    public List<Friends> friends;

    [HideInInspector] public string[] names;

    public AudioMixerGroup Mixer;

    void Start()
    {
        stage = 1;
        Do();
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
        PlayMusic("Nikfus - Dialogue");
    }
    public void EndBattle()
    {
        ++stage;
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

    public void Do()
    {
        //Временное решение?
        switch (stage) {
            case 1:
                PlayMusic("Nikfus - Lullaby");
                break;
            case 2:
                for(int i=0; i<3; ++i)
                {
                    switch(names[i])
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
                Pages.Add(Instantiate(FirstPage, transform));
                //Активируем первую страницу
                Pages[1].SetActive(true);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
