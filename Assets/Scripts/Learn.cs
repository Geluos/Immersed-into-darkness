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
        for (int i = 0; i < e.Length; i++)
        {
            e[i].AttackCooldown = 1000;
            e[i].isLearn = true;
        }
    }

    public void Next()
    {
        g[i - 1].SetActive(false);
        if (i == g.Length-1)
        {
            for (int i = 0; i < e.Length; i++)
            {
                e[i].hp = 0;
                e[i].isLearn = false;
            }
        }
        else
        {
            g[i].SetActive(true);
            i++;
        }
    }

}
