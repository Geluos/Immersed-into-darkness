using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToNextStage : MonoBehaviour
{
    private GameObject MainController;

    private MainController MC;
    // Start is called before the first frame update
    void Start()
    {
        MainController = GameObject.FindGameObjectWithTag("GameController");
        MC = MainController.GetComponent<MainController>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MC.NextStage();
        }
    }
}
