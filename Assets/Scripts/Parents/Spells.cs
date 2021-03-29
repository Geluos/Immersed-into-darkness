using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour
{
	public FightController fight;
	public virtual void SpellUseAll(bool IsFriends)
	{
		print("Применение ненаправленной способности");
	}
	public virtual void SpellUseTarget(Characters character)
	{
		print("Применение направленной способности");
	}
}