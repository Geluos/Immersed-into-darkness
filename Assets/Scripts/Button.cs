using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public FightController fight;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fight.res = true;
        }
    }
}
