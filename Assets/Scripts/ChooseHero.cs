using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHero : MonoBehaviour
{
    public GameObject[] icon = new GameObject[3];
    public string[] names = new string[3];
    public GameObject[] iconHero = new GameObject[4];

    public void TakeName(ref string[] names, string name)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == "" && names[0] != name && names[1] != name && names[2] != name)
            {
                names[i] = name;
                IconHero(name, i);
                break;
            }
        }
    }

    public void DeleteHero(ref string[] names, string name)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if(names[i]==name)
            {
                names[i] = "";
                break;
            }
        }
    }

    private void IconHero(string name, int ind)
    {
        switch (name)
        {
            case "swordsman":
                Instantiate(iconHero[0], icon[ind].transform);
                break;
            case "doctor":
                Instantiate(iconHero[1], icon[ind].transform);
                break;
            case "alchemist":
                Instantiate(iconHero[2], icon[ind].transform);
                break;
            case "rifflewoman":
                Instantiate(iconHero[3], icon[ind].transform);
                break;
        }
    }

    public void ButtonStart()
    {
        if (names[2] != "" && names[1] != "" && names[0] != "")
        {
            SceneManager.LoadScene("StoryScene");
            var GC = GameObject.FindWithTag("GameController").GetComponent<MainController>();
            GC.stage = 2;
            GC.names = names;
            GC.StopMusic();
            GC.PlayMusic("Nikfus - Dialogue");
            GC.Do();
            //print("Do");
        } 
        else 
        {
            print("Нужно выбрать 3 героя");
        }
    }

}
