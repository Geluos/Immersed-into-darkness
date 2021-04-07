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

    void Start()
    {
        
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

    public void Do()
    {
        print("Раз");
        //if (SceneManager.GetActiveScene().name == "StoryScene")
        print("Два");
        Pages.Add(Instantiate(FirstPage, transform));
        //Активируем первую страницу
        Pages[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
