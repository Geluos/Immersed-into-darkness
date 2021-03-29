using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconHero : MonoBehaviour
{
	[HideInInspector] public SpriteRenderer Sprite;
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }
}
