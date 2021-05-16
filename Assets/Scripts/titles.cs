using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titles : MonoBehaviour
{
    public GameObject ButtonExit;
    // Start is called before the first frame update
    void Start()
    {
        ButtonExit.SetActive(false);
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(0, 0.3f);
        if(gameObject.transform.position.y>2400)
        {
            ButtonExit.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
