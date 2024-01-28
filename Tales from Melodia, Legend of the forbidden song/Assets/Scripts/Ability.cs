using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ability : MonoBehaviour
{
    Combathandler combathandler;

    private string Color;

    private string Name;
    private int Mindmg;
    private int Maxdmg;
    private float Hitchance;
    private int StatusID;
    private float StatusChance;
    private int StatusStrenght;
    private int StatusDuration;
    private int Flowbonus;

    private bool Hitrank1;
    private bool Hitrank2;
    private bool Hitrank3;

    private bool Hit1and2;
    private bool Hit2and3;
    private bool Hitall;

    [SerializeField] int Abilitynum;

    void Awake()
    {
        combathandler = GameObject.Find("Combathandler").GetComponent<Combathandler>();

        GetCharacterAbilities(1);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCharacterAbilities(int characternum)
    {
        if (characternum == 1)
        {
            //Get ability data
            if (Abilitynum == 1)
            {
                Color = Gamedata.Position1.Ability1.Color;

                Name = Gamedata.Position1.Ability1.Name;
                Mindmg = Gamedata.Position1.Ability1.Mindmg;
                Maxdmg = Gamedata.Position1.Ability1.Maxdmg;
                Hitchance = Gamedata.Position1.Ability1.Hitchance;
                StatusID = Gamedata.Position1.Ability1.StatusID;
                StatusChance = Gamedata.Position1.Ability1.StatusChance;
                StatusStrenght = Gamedata.Position1.Ability1.StatusStrenght;
                StatusDuration = Gamedata.Position1.Ability1.StatusDuration;
                Flowbonus = Gamedata.Position1.Ability1.Flowbonus;

                Hitrank1 = Gamedata.Position1.Ability1.Hitrank1;
                Hitrank2 = Gamedata.Position1.Ability1.Hitrank2;
                Hitrank3 = Gamedata.Position1.Ability1.Hitrank3;

                Hit1and2 = Gamedata.Position1.Ability1.Hit1and2;
                Hit2and3 = Gamedata.Position1.Ability1.Hit2and3;
                Hitall = Gamedata.Position1.Ability1.Hitall;
            }
            if (Abilitynum == 2)
            {
                Color = Gamedata.Position1.Ability2.Color;

                Name = Gamedata.Position1.Ability2.Name;
                Mindmg = Gamedata.Position1.Ability2.Mindmg;
                Maxdmg = Gamedata.Position1.Ability2.Maxdmg;
                Hitchance = Gamedata.Position1.Ability2.Hitchance;
                StatusID = Gamedata.Position1.Ability2.StatusID;
                StatusChance = Gamedata.Position1.Ability2.StatusChance;
                StatusStrenght = Gamedata.Position1.Ability2.StatusStrenght;
                StatusDuration = Gamedata.Position1.Ability2.StatusDuration;
                Flowbonus = Gamedata.Position1.Ability2.Flowbonus;

                Hitrank1 = Gamedata.Position1.Ability2.Hitrank1;
                Hitrank2 = Gamedata.Position1.Ability2.Hitrank2;
                Hitrank3 = Gamedata.Position1.Ability2.Hitrank3;

                Hit1and2 = Gamedata.Position1.Ability2.Hit1and2;
                Hit2and3 = Gamedata.Position1.Ability2.Hit2and3;
                Hitall = Gamedata.Position1.Ability2.Hitall;
            }
            if (Abilitynum == 3)
            {
                Color = Gamedata.Position1.Ability3.Color;

                Name = Gamedata.Position1.Ability3.Name;
                Mindmg = Gamedata.Position1.Ability3.Mindmg;
                Maxdmg = Gamedata.Position1.Ability3.Maxdmg;
                Hitchance = Gamedata.Position1.Ability3.Hitchance;
                StatusID = Gamedata.Position1.Ability3.StatusID;
                StatusChance = Gamedata.Position1.Ability3.StatusChance;
                StatusStrenght = Gamedata.Position1.Ability3.StatusStrenght;
                StatusDuration = Gamedata.Position1.Ability3.StatusDuration;
                Flowbonus = Gamedata.Position1.Ability3.Flowbonus;

                Hitrank1 = Gamedata.Position1.Ability3.Hitrank1;
                Hitrank2 = Gamedata.Position1.Ability3.Hitrank2;
                Hitrank3 = Gamedata.Position1.Ability3.Hitrank3;

                Hit1and2 = Gamedata.Position1.Ability3.Hit1and2;
                Hit2and3 = Gamedata.Position1.Ability3.Hit2and3;
                Hitall = Gamedata.Position1.Ability3.Hitall;
            }
            if (Abilitynum == 4)
            {
                Color = Gamedata.Position1.Ability4.Color;

                Name = Gamedata.Position1.Ability4.Name;
                Mindmg = Gamedata.Position1.Ability4.Mindmg;
                Maxdmg = Gamedata.Position1.Ability4.Maxdmg;
                Hitchance = Gamedata.Position1.Ability4.Hitchance;
                StatusID = Gamedata.Position1.Ability4.StatusID;
                StatusChance = Gamedata.Position1.Ability4.StatusChance;
                StatusStrenght = Gamedata.Position1.Ability4.StatusStrenght;
                StatusDuration = Gamedata.Position1.Ability4.StatusDuration;
                Flowbonus = Gamedata.Position1.Ability4.Flowbonus;

                Hitrank1 = Gamedata.Position1.Ability4.Hitrank1;
                Hitrank2 = Gamedata.Position1.Ability4.Hitrank2;
                Hitrank3 = Gamedata.Position1.Ability4.Hitrank3;

                Hit1and2 = Gamedata.Position1.Ability4.Hit1and2;
                Hit2and3 = Gamedata.Position1.Ability4.Hit2and3;
                Hitall = Gamedata.Position1.Ability4.Hitall;
            }
        }
    }

    public void OnMouseDown()
    {
        if (combathandler.playercanact)
        {
            Debug.Log("Ability clicked");
            combathandler.AbilityUsed(Color, Name, Mindmg, Maxdmg, Hitchance, StatusID, StatusChance, StatusStrenght, StatusDuration, Flowbonus, Hitrank1, Hitrank2, Hitrank3, Hit1and2, Hit2and3, Hitall);
        }
    }

}
