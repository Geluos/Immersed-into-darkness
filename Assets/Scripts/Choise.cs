using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choise : MonoBehaviour
{
    public string nameHero;
    public GameObject cc;

    public bool is_icon;

    private void Start()
    {
        cc = GameObject.FindGameObjectWithTag("ChooseController");
    }
    private void OnMouseDown()
    {
        ChooseHero ch = cc.GetComponent<ChooseHero>();
        if(is_icon)
        {
            ch.DeleteHero(ref ch.names, nameHero);
            GameObject.Destroy(gameObject);
        }
        else
            ch.TakeName(ref ch.names, nameHero);
    }

}
