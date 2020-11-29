using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
	public FightController fight;

	void Start()
	{
		fight = (GameObject.FindWithTag("FightController")).GetComponent<FightController>();
	}
	
    public void SetMaxMana()
    {
		if (fight.CurrentUnit!=null)
		{
			slider.maxValue = fight.CurrentUnit.maxmana;
			slider.value = fight.CurrentUnit.mana;
		}
    }

    public void SetMana()
    {
		if (fight.CurrentUnit!=null)
		{
			if (slider.value != fight.CurrentUnit.mana/fight.CurrentUnit.maxmana)
			{slider.value = fight.CurrentUnit.mana/fight.CurrentUnit.maxmana;}
		}
    }
	
	void Update()
	{
		SetMana();
	}
}
