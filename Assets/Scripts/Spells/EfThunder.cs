using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfThunder : Effects
{
    // Start is called before the first frame update
    void Start()
    {
		a=1f;
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = new Color (1f, 1f, 1f, a);
    }

    // Update is called once per frame
    void Update()
    {
        a-=0.7f * Time.deltaTime;
		sprite.color = new Color (1f, 1f, 1f, a);
		if (a<=0) 
		{
			Destroy(gameObject);
		}
    }
}
