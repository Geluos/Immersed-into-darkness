using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Spells
{
	public GameObject ThunderPref;
	private Vector3 vec;

	public GameObject backGround;
	private int start;
	private SpriteRenderer spritebg;
	private GameObject thunder;

    private void Start()
    {
		spritebg = backGround.GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
		if (start == 1)
		{ spritebg.color = new Color(0f, 0f, 0.5f); start = 0; }
        if (thunder == null) { spritebg.color = new Color(1f, 1f, 1f); }
	}

    public override void SpellUseAll(bool IsFriends)
	{
		start = 1;
		if (IsFriends)
		{
			print("Противники поражены разрядом молнии");
			for (int i=0; i<fight.enemies.Count;i+=1)
			{
				thunder = Instantiate(ThunderPref, fight.enemies[i].transform.position, transform.rotation);
				fight.enemies[i].hp-=40;
			}
		}
		else
		{
			print("Союзники поражены разрядом молнии");
		}
	}
}
