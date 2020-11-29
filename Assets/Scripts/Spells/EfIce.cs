using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfIce : Effects
{
    // Start is called before the first frame update
	public Characters character;
    void Start()
    {
		a=1f;
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = new Color (1f, 1f, 1f, a);
    }

    // Update is called once per frame
    void Update()
    {
		if (time<=0)
		{
			a-=1f * Time.deltaTime;
			sprite.color = new Color (1f, 1f, 1f, a);
		}
		else
		{
			time-=Time.deltaTime;
		}
		if (a<=0) 
		{
			character.IsFreezing=false;
			Destroy(gameObject);
			character.FreezeParticle.GetComponent<ParticleSystem>().Stop();
			Destroy(character.FreezeParticle.gameObject,5f);
			character.FreezeParticle=null;
		}
    }
}
