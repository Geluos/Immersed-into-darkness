using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfFlame : Effects
{
	public Characters character;
	public float damage;
	private float interval;
	public GameObject smoke;

    void Update()
    {
		if (time<=0)
		{
			Destroy(gameObject);
			Destroy(smoke);
		}
		else
		{
			if (interval<=0)
			{
				character.hp-=5;
				interval=1;
			}
			else
			{
				interval-=Time.deltaTime;
			}
			time-=Time.deltaTime;
		}
    }
}
