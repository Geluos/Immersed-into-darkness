using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCell : MonoBehaviour
{
	public int index;
	public Sprite DefaultSprite;
	public SpriteRenderer Sprite;
	public GlobalController controller;
	public GameObject ItemSelectedPref;
    // Start is called before the first frame update
    void Start()
    {
        Sprite=GetComponent<SpriteRenderer>();
    }
	
	void OnMouseOver()
	{ 
		if ((Input.GetMouseButtonDown(0))&&(controller.ItemNotEmpty[index])&&(controller.Selected == null))
		{
			Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var Selected = (Instantiate(ItemSelectedPref, mousePos, transform.rotation)).GetComponent<ItemSelected>();
			controller.Selected = Selected;
			Selected.controller = controller;
			Selected.sprite = controller.ItemSprite[index];
			Selected.index = index;
		}
		if ((Input.GetMouseButtonUp(0))&&(controller.Selected != null))
		{
			if (controller.Selected.index != index)
			{
				controller.ItemSwap(controller.Selected.index,index);
			}
		}
	}
	
	void Update()
	{
		if (controller.Selected == null)
		{
			if (controller.ItemSprite[index]!=Sprite.sprite)
			{
				Sprite.sprite = controller.ItemSprite[index];
			}
		}
		else
		{
			if ((Sprite.sprite!=null) && (controller.Selected.index == index))
			{
				Sprite.sprite=null;
			}
		}
	}
}
