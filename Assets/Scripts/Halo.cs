using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ореол вокруг спрайта
public class Halo : MonoBehaviour
{
	public SpriteRenderer spr;
	public Color color = Color.yellow;
	public Material material;
    void Awake()
	{
		spr = GetComponent<SpriteRenderer>();
		material = spr.material;
	}
    void Start()
    {
		if (spr!=null)
		{
			spr.material = material;
			spr.color = color;
			transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
		}
    }

}
