using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPortion : MonoBehaviour
{
	[HideInInspector] public MainController controller;
	[HideInInspector] public InfoBar info;
	public string text;

    private void Awake()
    {
		controller = GameObject.FindWithTag("GameController").GetComponent<MainController>();
    }
    void OnMouseOver()
	{
			if (info != null) info.delete = false;
			if (controller.infoBar == null)
			{
				controller.infoBar = Instantiate(controller.InfoBarPref, transform.position, transform.rotation);
				info = controller.infoBar.GetComponent<InfoBar>();
				info.text = text;
			}
	}
}
