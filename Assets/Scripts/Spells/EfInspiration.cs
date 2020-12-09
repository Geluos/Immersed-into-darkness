using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfInspiration : Effects
{
	private Vector3 scale;
	private float b;

	void Start()
	{
		scale = transform.localScale;
		a = 1f;
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = new Color(1f, 1f, 1f, a);
	}

	// Update is called once per frame
	void Update()
	{
		a -= 0.4f * Time.deltaTime;
		transform.localScale = new Vector3(scale.x * (3 - 3 * a), scale.y * (3 - 3 * a), scale.z);
		transform.position = new Vector2(transform.position.x, transform.position.y + b);
		b += 0.008f;
		sprite.color = new Color(1f, 1f, 1f, a);
		if (a <= 0)
		{
			Destroy(gameObject);
		}
	}
}
