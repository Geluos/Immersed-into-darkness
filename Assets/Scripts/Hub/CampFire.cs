using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CampFire : MonoBehaviour
{
    public Light2D MyLight;
    private float xStart;
    private float yStart;
    void Start()
    {
        xStart = transform.position.x;
        yStart = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector2(xStart + Random.Range(-1, 1), yStart + Random.Range(-1, 1));
        if(MyLight.intensity>0.3&& MyLight.intensity<0.7)
            MyLight.intensity += (float)Random.Range(-1, 2) / 50;
        else
        {
            if (MyLight.intensity > 0.3)
                MyLight.intensity += -0.05f;
            else
                MyLight.intensity += 0.05f;
        }
    }
}
