using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Status : MonoBehaviour
{
    public string Name;
    public float power;
    public float level;

    public float lifetime;
    public float period;
    public bool manyRoom;
    public int last_fight;
    public Characters character;
    [HideInInspector] public float time;

    public InfoBar Info;
    [HideInInspector] public MainController controller;

    public void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<MainController>();
        if (character!=null)
        {
            //transform.SetParent(character.transform);
            character.StatusList.Add(this);
            character.RefreshStatusIcons();
        }
        else
        {
            Destroy(gameObject);
        }
        time = period;
    }

    public void OnMouseOver()
    {
        if (Info != null) Info.delete = false;
        if (controller.infoBar == null)
        {
            controller.infoBar = Instantiate(controller.InfoBarPref, transform.position, transform.rotation);
            Info = controller.infoBar.GetComponent<InfoBar>();
            Info.text = Information.GetEffectInfo(Name, level, power);
            if ( Time.timeScale == 0f)
            {
                Info.text += $"\n\n<color=\"green\"><b>Осталось:</b> {Mathf.Ceil(lifetime*10)/10} сек.<color=\"white\">";
            }
        }
    }

    public void OnDestroy()
    {
        character?.StatusList.Remove(this);
        character?.RefreshStatusIcons();
    }
    public void Update()
    {
        if (character != null)
        {
            time = Math.Max(0, time - Time.deltaTime);
            lifetime -= Time.deltaTime;
            if (lifetime < 0f)
            {
                character.StatusList.Remove(this);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
