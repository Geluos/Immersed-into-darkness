using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonToBattle : MonoBehaviour
{
    public GameObject MainController;
    public GameObject NextPage;

    private MainController MC;
    // Start is called before the first frame update
    void Start()
    {
        MainController = GameObject.FindGameObjectWithTag("GameController");
        MC = MainController.GetComponent<MainController>();
    }

    void OnMouseOver()
	{
        if(Input.GetMouseButtonDown(0))
        {
            //Здесь устанавливаем в MainController все данные о бое

            //Перестать отображть page
            MC.StopMusic();
            MC.UnActiveLastPage();
            if(MC.stage==2)
                SceneManager.LoadScene("FightSceneWolfs");
            else if(MC.stage == 3)
                SceneManager.LoadScene("FightSceneShark");
            else
                SceneManager.LoadScene("Goddes");
            MC.BattlePage = NextPage;
        }
    }
}
