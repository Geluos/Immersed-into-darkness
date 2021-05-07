using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellDescription : MonoBehaviour
{
    public string Name;
    public TextMeshProUGUI Text;
    void Start()
    {
        Text.text = Information.GetSpellInfo(Name);
    }
}
