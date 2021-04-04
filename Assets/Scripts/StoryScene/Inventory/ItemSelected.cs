using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
	public SpriteRenderer render;
    public Sprite sprite;
	
	public int index;
	public GlobalController controller;
	
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
		render.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!Input.GetMouseButton(0))
		{
			Destroy(gameObject);
		}
    }
}
