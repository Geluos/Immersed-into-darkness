﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PageScript : MonoBehaviour
{
    public double textSpeed = 3.4;
    public double time;
    public GameObject Text;

    public List<GameObject> buttonsList;

    public string txt;

    private string ptxt = "";
    private int tpos = 0;
    public bool printed = false;

    // Start is called before the first frame update
    void Start()
    {
        time = textSpeed;
        foreach(GameObject but in buttonsList)
        {
            but.SetActive(false);
        }
    }

    void Initialize()
    {
        //Здесь мы скрываем все варианты ответа, если страница не последняя
        if(printed)
        {

        }
    }

    void show_All_Buttons()
    {
        foreach(GameObject but in buttonsList)
        {
            but.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!printed)
        {
            if(time<=0)
            {
                if(tpos<txt.Length){
                    ptxt += txt[tpos];
                    ++tpos;
                    var t = Text.GetComponent<TextMeshProUGUI>();
                    t.text = ptxt;
                }
                else
                {
                    show_All_Buttons();
                    printed = true;
                }
                time = textSpeed;
            }
            else
            //здесь что-то с числом кадров в секунду
                time-=0.2;
        }
    }
}