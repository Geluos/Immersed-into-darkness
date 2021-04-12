using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public Light MyLight;
    private float iStart;
    private float xStart;
    private float yStart;
    void Awake()
    {
        iStart = MyLight.intensity;
        xStart = transform.position.x;
        yStart = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector2(xStart + Random.Range(-1, 1), yStart + Random.Range(-1, 1));
        MyLight.intensity = iStart + Random.Range(-3, 3);
    }
}
