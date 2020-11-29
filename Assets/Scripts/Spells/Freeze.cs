using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Spells
{
	public float time;
	public GameObject IcePref;

	private GameObject prefFreeze;
	private UnityEngine.Object prefEfFreeze;

	private void Start()
    {
		prefEfFreeze = Resources.Load("FreezeEffect");
	}

	public override void SpellUseTarget(Characters character)
	{
		print("Применена заморозка");
		if (character.EfFlame==null)
		{
			if (character.EfIce==null)
			{
				var ice = (Instantiate(IcePref, character.transform.position, transform.rotation)).GetComponent<EfIce>();
				character.IsFreezing=true;
				character.EfIce=ice;
				ice.time=time;
				ice.character=character;
				prefFreeze = (GameObject)Instantiate(prefEfFreeze);
				prefFreeze.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
				character.FreezeParticle=prefFreeze;
			}
			else
			{
				character.EfIce.time=time;
				character.EfIce.a=1f;
				character.EfIce.sprite.color = new Color (1f, 1f, 1f, character.EfIce.a);
			}
		}
		else
		{
			Destroy(character.EfFlame.gameObject);
		}
	}
}
