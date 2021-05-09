using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroInformation : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI States;
    public GameObject IsAlive;
    public SpriteRenderer spriteRend;
    public int num;
    [HideInInspector] public MainController controller;
    private List<HeroSpell> SpellList = new List<HeroSpell>();

    public GameObject HeroSpellPref;
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").GetComponent<MainController>();
        for (int i=0; i<3; i++)
        {
            var icon = Instantiate(HeroSpellPref, transform).GetComponent<HeroSpell>();
            icon.heroInformation = this;
            icon.transform.position = new Vector3(50 + i * 64, -160);
            SpellList.Add(icon);
        }
        RefreshInfo();
    }
    public void RefreshInfo()
    {
        spriteRend.sprite = controller.friends[num].spriteRend.sprite;
        Name.text = controller.friends[num].Name;
        States.text = GetStates(num);
        if (controller.friends[num].alive)
        {
            IsAlive.SetActive(false);
        }
        else
        {
            IsAlive.SetActive(true);
        }
        for (int i = 0; i<3; i++)
        {
            SpellList[i].spell = controller.friends[num].Spells[i];
            SpellList[i].spriteRend.sprite = SpellList[i].spell.sprite;
        }
    }
    public string GetStates(int num)
    {
        string output = $"<b>Здоровье:</b> {Mathf.Ceil(controller.friends[num].hp)}/{controller.friends[num].maxhp}\n" +
            $"<b>Опыт:</b> {controller.friends[num].CurrentExp}/{controller.friends[num].RequiredExp}\n" +
            $"<b>Уровень:</b> {controller.friends[num].Level}\n";
        if (controller.friends[num].defenceMultiply!=1)
        {
            output += $"<b>Блокировка урона:</b> {Mathf.Ceil((1 - controller.friends[num].defenceMultiply)*100)}\n";
        }
        if (controller.friends[num].power != 0)
        {
            output += $"<b>Усиление способностей:</b> {controller.friends[num].power}\n";
        }
        return output;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
