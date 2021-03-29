using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCreator : MonoBehaviour
{
	public string text;
	public bool Storyline = true; //Является ли текст сюжетным
	private float time = 1;
	private GlobalController controller;
	private int str = 0;
	
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
		controller.TextCreator = GetComponent<TextCreator>();
    }

    void Update()
    {
		if (time<=0)
		{
			if (str<text.Length)
			{
				if (text[str]==' ')
				{
					controller.TextMesh2.text=controller.page[controller.page.Count-1];
					controller.TextMesh2.ForceMeshUpdate();
					var height = controller.TextMesh2.GetRenderedValues()[1]; //текущая высота строки
					
					int temp = str+1;
					bool b=true;
					while (text[temp]!=' ')
					{
						temp++;
						if (text[temp]=='\n') 
						{
							b=false;
							break;
						}
						if (temp==text.Length-1) {break;}
					}
					
					if (b)
					{
						controller.TextMesh2.text+=text.Substring(str,temp-str+1);
						controller.TextMesh2.ForceMeshUpdate();
						if (controller.TextMesh2.GetRenderedValues()[1]>height)
						{
							if (controller.TextMesh2.firstOverflowCharacterIndex!=-1)
							{
								controller.page.Add("");
							}
							else
							{
								controller.page[controller.page.Count-1]+='\n';
							}
							str++;
						}	
					}					
				}
				if (text[str]!='<')
				{
					controller.page[controller.page.Count-1]+=text[str];
					str+=1;
					time=1f;
				}
				else
				{
					int t=str+1;
					while(text[t]!='>') {t+=1;};
					controller.page[controller.page.Count-1]+=text.Substring(str,t-str+1);
					str=t+1;
				}
			}
			else
			{
				controller.ScriptProgress++;
				Destroy(gameObject);
			}
		}
		else
		{
			time-=30f*Time.deltaTime;
		}
		if ((Input.GetMouseButtonDown(0))&&(controller.number==controller.page.Count-1)&&(controller.r_arrow.spr.color!=controller.r_arrow.col1)&&(controller.l_arrow.spr.color!=controller.l_arrow.col1))
		{
			text=controller.page[controller.page.Count-1]+text.Substring(str,text.Length-str);
			controller.TextMesh2.text=text;
			controller.page[controller.page.Count-1]=text;
			controller.TextMesh2.ForceMeshUpdate();
			while (controller.TextMesh2.firstOverflowCharacterIndex!=-1)
			{
				int ind = controller.TextMesh2.firstOverflowCharacterIndex;
				while (controller.TextMesh2.text[ind]!=' ') {ind--;}
				controller.page[controller.page.Count-1]=text.Substring(0,ind);
				text=text.Substring(ind,text.Length-ind);
				controller.TextMesh2.text=text;
				controller.TextMesh2.ForceMeshUpdate();
				controller.page.Add(text);
			}
			if (Storyline)
			{
				controller.ScriptProgress++;
			}
			Destroy(gameObject);
		}
    }
}
