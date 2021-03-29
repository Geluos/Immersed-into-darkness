using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfFireball : Effects
{
    public float speed;
    public int damage;
    [HideInInspector] public Characters character;
	[HideInInspector] public FightController fight;
    private Transform vec;

    private GameObject prefFB;
    private UnityEngine.Object prefEfFB;

    private void Start()
    {
        vec = character.transform;
        prefEfFB = Resources.Load("FireBallEffect");
        prefFB = (GameObject)Instantiate(prefEfFB);
    }

    void Update()
    {
        if ((character != null)&&(fight.friends.Count != 0))
        {
            transform.position = Vector2.MoveTowards(transform.position, vec.position, speed * Time.deltaTime);
            prefFB.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if (vec.position == gameObject.transform.position)
            {
                character.hp -= damage;
                Destroy(gameObject);
                Destroy(prefFB);
            }
        } 
        else 
        { 
            //GameObject pS = Instantiate(Play_Sound, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject); 
        }
    }

}
