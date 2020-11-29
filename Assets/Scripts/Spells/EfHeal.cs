using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfHeal : Effects
{
	private Vector3 scale;
    void Start()
    {
		scale=transform.localScale;
		a=1f;
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = new Color (1f, 1f, 1f, a);
    }

    // Update is called once per frame
    void Update()
    {
        a-=0.4f * Time.deltaTime;
		transform.localScale = new Vector3(scale.x*(3-3*a), scale.y*(3-3*a), scale.z);
		sprite.color = new Color (1f, 1f, 1f, a);
		if (a<=0) 
		{
			Destroy(gameObject);
		}
    }
}
