using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	private float a;
	private SpriteRenderer sprite;
    void Start()
    {
		a=2f;
		gameObject.transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360f));
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
