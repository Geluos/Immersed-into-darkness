using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
	public FightController fight;

	void Start()
	{
		fight = (GameObject.FindWithTag("FightController")).GetComponent<FightController>();
	}
	
    public void SetMaxHealth()
    {
		if (fight.CurrentUnit!=null)
		{
			slider.maxValue = fight.CurrentUnit.maxhp;
			slider.value = fight.CurrentUnit.hp;
		}
    }

    public void SetHealth()
    {
		if (fight.CurrentUnit!=null)
		{
			if (slider.value != fight.CurrentUnit.hp/fight.CurrentUnit.maxhp)
			{slider.value = fight.CurrentUnit.hp/fight.CurrentUnit.maxhp;}
		}
    }
	
	void Update()
	{
		SetHealth();
	}
}
