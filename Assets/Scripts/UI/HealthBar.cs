using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
	public float height;
	[HideInInspector] public Characters character;
	[HideInInspector] public GameObject canvas;

	void Start()
	{

	}
	
    public void SetMaxHealth()
    {
		if (character!=null)
		{
			slider.maxValue = character.maxhp;
			slider.value = character.hp;
		}
    }

    public void SetHealth()
    {
		if (character!=null)
		{
			//gameObject.transform.position=character.gameObject.transform.position+new Vector3(0,0,0);
			if (slider.value != character.hp)
			{
				slider.value = character.hp;
			}
		} 
		else
		{
			Destroy(canvas);
		}
    }
	
	void Update()
	{
		SetHealth();
	}
}
