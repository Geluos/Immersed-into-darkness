using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    public GameObject[] g = new GameObject[7];
    private int i = 0;

    public Enemies[] e = new Enemies[3];

    private void Start()
    {
        g[i].SetActive(true);
        i++;
        for (int j = 0; j < e.Length; j++)
        {
            e[j].DamageMax = 0;
            e[j].DamageMin = 0;
            e[j].isLearn = true;
        }
    }

    public void Next()
    {
        g[i - 1].SetActive(false);
        g[i].SetActive(true);
        i++;
    }

    public void Close()
    {
        print(1);
        g[6].SetActive(false);
        for (int j = 0; j < e.Length; j++)
        {
            e[j].DamageMax = 8;
            e[j].DamageMin = 5;
            e[j].hp = 80;
            e[j].isLearn = false;
        }
    }

}
