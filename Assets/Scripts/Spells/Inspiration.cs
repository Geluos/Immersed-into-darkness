using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspiration : Spells
{
	public GameObject InsPref;
	private Vector2 vec;
	public float insp;
	public float time;
	public float regen;

	public override void SpellUseTarget(Characters character)
	{
		vec = new Vector2(character.transform.position.x-0.1f, character.transform.position.y + 1.2f);
		Instantiate(InsPref, vec, transform.rotation);
		character.insp = 1;
		character.minusCtime = insp;
		character.time = time;
		character.regen = regen;
	}
}
