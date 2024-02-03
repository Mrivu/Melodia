using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Enemy;
using static Gamedata;

public class Enemy : MonoBehaviour
{
    public int Maxhp;
    public int Hp;
    public int Speed;
    public string Name;
    public float Dodge;

    public bool Enemyslotted;
    public int Enemynumber;

    public int HasStatusID = 0;
    public int StatusStrenght;
    public int StatusDuration;

    public int AI;

    public int mindmg1;
    public int maxdmg1;
    public float hit1;
    public int flowreduction1;

    public int mindmg2;
    public int maxdmg2;
    public float hit2;
    public int flowreduction2;

    public int mindmg3;
    public int maxdmg3;
    public float hit3;
    public int flowreduction3;

    public int mindmg4;
    public int maxdmg4;
    public float hit4;
    public int flowreduction4;

    public bool Dazed = false;

    public Vector2 podiumPosition;

    public bool hasTurn;

    //ID,STRENGHT,DURATION
    public List<StatusEffect> ActiveStatus = new List<StatusEffect>();

    public StatustokenHandler statustokenHandler;

    private void Awake()
    {
        statustokenHandler = gameObject.GetComponent<StatustokenHandler>();

        if (Enemynumber == 1)
        {
            Maxhp = Gamedata.Enemy1.Maxhp;
            Hp = Gamedata.Enemy1.Hp;
            Speed = Gamedata.Enemy1.Speed;
            Name = Gamedata.Enemy1.Name;
            Dodge = Gamedata.Enemy1.Dodge;

            Enemyslotted = Gamedata.Enemy1.Enemyslotted;

            HasStatusID = Gamedata.Enemy1.HasStatusID;
            StatusDuration = Gamedata.Enemy1.StatusDuration;
            StatusStrenght = Gamedata.Enemy1.StatusStrenght;

            AI = Gamedata.Enemy1.AI;

            #region abilities
            mindmg1 = Gamedata.Enemy1.AIability1.mindmg;
            maxdmg1 = Gamedata.Enemy1.AIability1.maxdmg;
            hit1 = Gamedata.Enemy1.AIability1.hit;
            flowreduction1 = Gamedata.Enemy1.AIability1.flowreduction;

            mindmg2 = Gamedata.Enemy1.AIability2.mindmg;
            maxdmg2 = Gamedata.Enemy1.AIability2.maxdmg;
            hit2 = Gamedata.Enemy1.AIability2.hit;
            flowreduction2 = Gamedata.Enemy1.AIability2.flowreduction;

            mindmg3 = Gamedata.Enemy1.AIability3.mindmg;
            maxdmg3 = Gamedata.Enemy1.AIability3.maxdmg;
            hit3 = Gamedata.Enemy1.AIability3.hit;
            flowreduction3 = Gamedata.Enemy1.AIability3.flowreduction;

            mindmg4 = Gamedata.Enemy1.AIability4.mindmg;
            maxdmg4 = Gamedata.Enemy1.AIability4.maxdmg;
            hit4 = Gamedata.Enemy1.AIability4.hit;
            flowreduction4 = Gamedata.Enemy1.AIability4.flowreduction;
            #endregion
        }
    }

    public void CheckStatus()
    {
        Debug.Log("Checkstatuscall");
        Debug.Log("Status ListLength " + ActiveStatus.Count);
        for (int status = 0; status < ActiveStatus.Count; status++)
        {
            Debug.Log("Current duration " + ActiveStatus[status].ListStatusDuration);
            ActiveStatus[status].ListStatusDuration--;
            Debug.Log("Current duration " + ActiveStatus[status].ListStatusDuration);

            //Check abilityID and do ability
            switch (ActiveStatus[status].ListStatusID)
            {
                //ID,STRENGHT,DURATION
                case 1:
                    //Daze
                    Dazed = true;
                    break;
                case 2:
                    //Voltage
                    Hp -= ActiveStatus[status].ListStatusStrenght;
                    break;
            }

            if (ActiveStatus[status].ListStatusDuration <= 0)
            {
                if (ActiveStatus[status].ListStatusID == 1) { Dazed = false; }

                Debug.Log("Removed");
                ActiveStatus.Remove(ActiveStatus[status]);
            }
        }
        gameObject.GetComponent<StatustokenHandler>().UpdateTokens();
    }

    public class StatusEffect
    {
        public int ListStatusID { get; set; }
        public int ListStatusStrenght { get; set; }
        public int ListStatusDuration{ get; set; }
    }


    void Start()
    {
    }

    void Update()
    {
    }
}
