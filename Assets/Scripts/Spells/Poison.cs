using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Spells
{
	public float PoisonPower;
	public GameObject PoisonPref;

	private GameObject prefPoison;
	private UnityEngine.Object prefEfPoison;


    private void Start()
    {
		prefEfPoison = Resources.Load("PoisonEffect");
	}

    public override void SpellUseTarget(Characters character)
	{
		print("Применено отравление");
		if (character.PoisonParticle==null)
		{
			Instantiate(PoisonPref, character.transform.position, transform.rotation);
			prefPoison = (GameObject)Instantiate(prefEfPoison);
			prefPoison.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
			character.PoisonParticle=prefPoison;
		}
		character.PoisonDamage+=PoisonPower;
	}

}
