using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{

    //Изначально 
    public GameObject FirstPage;

    //Пока публичный для просмотра
    public List<GameObject> Pages;

    public int stage;
    //1 - Хаб
    //2 - Начальный текст

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

    public IEnumerator PlayMusic(string name)
    {
        yield return new WaitForSeconds(0.5f);
        print("Музука");
        gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("name");
        gameObject.GetComponent<AudioSource>().Play();
    }

    public IEnumerator StopMusic()
    {
        yield return new WaitForSeconds(0f);
        print("No musuca");
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public void Do()
    {
        //Временное решение?
        switch (stage) {
            case 1:
                StartCoroutine(PlayMusic("Nikfus - Lullaby"));
                break;
            case 2:
                Pages.Add(Instantiate(FirstPage, transform));
                //Активируем первую страницу
                Pages[0].SetActive(true);
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
