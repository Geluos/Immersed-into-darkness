using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectDescription : MonoBehaviour
{
    public List<string> Name = new List<string>();
    public InfoPortion info;
    void Start()
    {
        string text = "";
        foreach (var x in Name)
        {
            text += Information.GetEffectInfo(x) + '\n';
        }
        info.text = text;
    }
}