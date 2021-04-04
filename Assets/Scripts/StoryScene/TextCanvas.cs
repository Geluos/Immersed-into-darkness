using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCanvas : MonoBehaviour
{
    void Start()
    {
        var controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
		controller.Canvas=gameObject;
    }
}
