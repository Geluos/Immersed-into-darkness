using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpell : MonoBehaviour
{
    public HeroInformation heroInformation;
    public SpriteRenderer spriteRend;
	public Spells spell;
	public int num;
	public int level;

    public InfoBar Info;
    [HideInInspector] public MainController controller;
    public void Start()
    {
        controller = heroInformation.controller;
    }
	void OnMouseOver()
	{
		if (Info != null) Info.delete = false;
		if (controller.infoBar == null)
		{
			controller.infoBar = Instantiate(controller.InfoBarPref, transform.position, transform.rotation);
			Info = controller.infoBar.GetComponent<InfoBar>();
			Info.text = Information.GetSpellInfo(spell.Name, level, controller.friends[num].power);
			foreach (var x in spell.statusName)
			{
				Info.text += '\n' + Information.GetEffectInfo(x, level, controller.friends[num].power);
			}
			Info.text += $"\n\n<b>Перезарядка:</b> {spell.reloadtime}";
			Info.text += $"\n<b>Уровень:</b> { level + 1}";
		}
	}
}
