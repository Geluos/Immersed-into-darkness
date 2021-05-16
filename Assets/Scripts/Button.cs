using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public FightController fight;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var GC = GameObject.FindWithTag("GameController");
            Destroy(GC);
            SceneManager.LoadScene("Menu");
        }
    }
}
