using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
	public List<DBranch> BranchList = new List<DBranch>();
	public GameObject DBranchPref;
	public bool ExtraPage = false; //Создается ли дополнительная страница?
	
	public GlobalController controller;
	
	public void AddBranch(string text)
	{
		var branch=(Instantiate(DBranchPref, transform.position, transform.rotation)).GetComponent<DBranch>();
		branch.text=text;
		branch.num=BranchList.Count;
		BranchList.Add(branch);
	}
	
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<GlobalController>();
		
		controller.TextMesh2.text=controller.page[controller.page.Count-1];
		for (int i=0; i<BranchList.Count; i++)
		{
			controller.TextMesh2.text+="\n"+BranchList[i].text;
		}
		controller.TextMesh2.ForceMeshUpdate();
		if (controller.TextMesh2.firstOverflowCharacterIndex!=-1)
		{
			ExtraPage=true;
			controller.page.Add("");
		}
		controller.TextMesh2.text=controller.page[controller.page.Count-1];
		controller.TextMesh2.ForceMeshUpdate();
		for (int i=0; i<BranchList.Count; i++)
		{
			BranchList[i].dialog=this;
			BranchList[i].transform.SetParent(transform);
			BranchList[i].page=controller.page.Count-1;
			BranchList[i].transform.position=new Vector2(controller.Text.transform.position.x,controller.Text.transform.position.y-controller.TextMesh2.GetRenderedValues()[1]);
			controller.TextMesh2.text+="\n"+BranchList[i].text;
			controller.TextMesh2.ForceMeshUpdate();
		}
		controller.DialogExtraPage=ExtraPage;
    }
}
