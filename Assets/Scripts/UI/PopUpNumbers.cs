using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpNumbers : MonoBehaviour
{
    public Color colDamage;
    public Color colHeal;
    public TextMeshProUGUI textMesh;
    public float number;
    private float alpha = 1f;

    void Start()
    {
        if (number < 0) 
            textMesh.color = colDamage; 
        else 
            textMesh.color = colHeal;
        textMesh.text = number.ToString();
    }
    void Update()
    {
        if (alpha>0)
        {
            alpha -= 0.4f * Time.deltaTime;
            textMesh.alpha = alpha;
            transform.position += new Vector3(0,6f*Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
