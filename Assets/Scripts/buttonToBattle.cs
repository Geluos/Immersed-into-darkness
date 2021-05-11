using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonToBattle : MonoBehaviour
{
    public GameObject MainController;
    public GameObject NextPage;
    public Sprite Background;
    public List<GameObject> Lights;
    public List<Enemies> EnemyList;

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
            MC.Background = Background;
            MC.Lights = Lights;
            MC.EnemyList = EnemyList;
            MC.ToFightScene();
            MC.BattlePage = NextPage;
        }
    }
}
