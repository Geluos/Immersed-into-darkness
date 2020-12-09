using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfShield : Effects
{
	private Vector3 scale;
    void Start()
    {
		scale=transform.localScale;
		a=0f;
		time=10;
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = new Color (1f, 1f, 1f, a);
    }

    // Update is called once per frame
    void Update()
    {
		if (a>0)
		{
			a-=0.8f * Time.deltaTime;
		} else {a=0;}
		if (time>0)
		transform.localScale = new Vector3(scale.x*(0.9f+time/100), scale.y*(0.9f+time/100), scale.z);
		sprite.color = new Color (1f, 1f, 1f, time/10+a);
		if (time>0) 
		{
			time-=Time.deltaTime;
		}
		else
		{
			if (a<=0)
			{
				Destroy(gameObject);
			}
		}
    }
}
