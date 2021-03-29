using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosian : MonoBehaviour
{
    public float timeExplosianStart;
    private float timeExplosian;

    private void Start()
    {
        timeExplosian = timeExplosianStart;
    }

    //Update
    void Update()
    {
        if (timeExplosian <= 0)
        {
            Destroy(gameObject);
            timeExplosian = timeExplosianStart;
        }
        timeExplosian -= Time.deltaTime;
    }
}
