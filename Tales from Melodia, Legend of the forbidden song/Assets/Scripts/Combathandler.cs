using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using TMPro;
using static Enemy;

public class Combathandler : MonoBehaviour
{
    public Enemy Enemy1;
    public Enemy Enemy2;
    public Enemy Enemy3;

    AIhandler aihandler;
    StatustokenHandler statustokenhandler;

    private AbilityExplanation abilityExplanation;

    [SerializeField] TurnTokens turnTokenManager;

    private MelodyHandler melodyhandler;

    public CombatAnimator combatanimator;
    public bool hit;

    public bool OngoingAnimation = false;

    public Character Character1;
    public Character Character2;
    public Character Character3;

    [SerializeField] GameObject Canhit1;
    [SerializeField] GameObject Canhit2;
    [SerializeField] GameObject Canhit3;

    [SerializeField] public GameObject Select_target;

    [SerializeField] TextMeshProUGUI roundtext;

    public Dictionary<string, int> CombatOrder = new Dictionary<string, int>();
    private Dictionary<string, int> CombatMembers = new Dictionary<string, int>();

    public int round = 1;
    public int turnnum = 0;

    public bool playercanact = false;
    public bool playerhasacted = false;

    public Enemy target;
    private Character character;
    private Enemy enemyintrun;

    //timer
    public float time;

    //Abilitydata
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

    public bool Hitrank1;
    public bool Hitrank2;
    public bool Hitrank3;

    public bool Hit1and2;
    public bool Hit2and3;
    public bool Hitall;

    void Awake()
    {
        Enemy1 = GameObject.Find("Enemy1").GetComponent<Enemy>();
        Character1 = GameObject.Find("Character1").GetComponent<Character>();
        Enemy2 = GameObject.Find("Enemy2").GetComponent<Enemy>();
        Character2 = GameObject.Find("Character2").GetComponent<Character>();
        Enemy3 = GameObject.Find("Enemy3").GetComponent<Enemy>();
        Character3 = GameObject.Find("Character3").GetComponent<Character>();

        aihandler = GameObject.Find("AI").GetComponent<AIhandler>();

        abilityExplanation = GameObject.Find("AbilityExplanation").GetComponent<AbilityExplanation>();

        combatanimator = GameObject.Find("CombatAnimator").GetComponent<CombatAnimator>();

        melodyhandler = GameObject.Find("Melody").GetComponent<MelodyHandler>();

        Select_target.SetActive(false);
    }

    void Start()
    {
        UpdateResouces();
        roundtext.text = "Round " + round;
        NewOrder();
        foreach (var item in CombatOrder)
        {
            Debug.Log(item.Key + ", " + item.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Combat
        if (turnnum < (CombatOrder.Count()))
        {
            if (!OngoingAnimation)
            {
                //Handle Player
                if (CombatOrder.ElementAt(turnnum).Key == "Character1" || CombatOrder.ElementAt(turnnum).Key == "Character2" || CombatOrder.ElementAt(turnnum).Key == "Character3")
                {
                    if (CombatOrder.ElementAt(turnnum).Key == "Character1")
                    {
                        character = GameObject.Find("Character1").GetComponent<Character>();
                    }
                    else if (CombatOrder.ElementAt(turnnum).Key == "Character2")
                    {
                        character = GameObject.Find("Character2").GetComponent<Character>();
                    }
                    else if (CombatOrder.ElementAt(turnnum).Key == "Character3")
                    {
                        character = GameObject.Find("Character3").GetComponent<Character>();
                    }
                    playercanact = true;
                    //wait for player action
                    if (playerhasacted)
                    {
                        if (character.FlowDur > 0)
                        {
                            character.FlowDur -= 1;
                        }

                        int damage = (int)System.Math.Round(Random.Range(Mindmg, Maxdmg + 1) * (1 + melodyhandler.modifier) * character.Flowdamage, 0);
                        string statusResist = null;

                        melodyhandler.ChangeMelody(Color);

                        //Check if hits
                        if (Random.Range(0.0f, 100.0f) <= Hitchance - target.Dodge + character.Flowhitchance)
                        {
                            hit = true;
                            #region Doability

                            if (Hit1and2)
                            {
                                //Add flow
                                character.Flow += 1 + Flowbonus;
                                if (character.Flow > character.Maxflow)
                                {
                                    character.Flow = character.Maxflow;
                                }

                                //Deal damage
                                if (Enemy1.Enemyslotted)
                                {
                                    Enemy1.Hp -= damage;
                                    if (StatusID != 0)
                                    {
                                        if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                        {
                                            StatusEffect statusEffect = new StatusEffect();
                                            statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                            Enemy1.ActiveStatus.Add(statusEffect);
                                            statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                        }
                                        else
                                        {
                                            statusResist = "Resisted";
                                        }
                                    }
                                }
                                if (Enemy2.Enemyslotted)
                                {
                                    Enemy2.Hp -= damage;
                                    if (StatusID != 0)
                                    {
                                        if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                        {
                                            StatusEffect statusEffect = new StatusEffect();
                                            statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                            Enemy1.ActiveStatus.Add(statusEffect);
                                            statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                        }
                                        else
                                        {
                                            statusResist = "Resisted";
                                        }
                                    }
                                }
                                Debug.Log("dmg: " + damage);
                                Debug.Log("EHP: " + target.Hp);
                            }
                            else if (Hit2and3)
                            {
                                //Add flow
                                character.Flow += 1 + Flowbonus;

                                //Deal damage
                                if (Enemy2.Enemyslotted)
                                {
                                    Enemy2.Hp -= damage;
                                    if (StatusID != 0)
                                    {
                                        if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                        {
                                            StatusEffect statusEffect = new StatusEffect();
                                            statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                            Enemy1.ActiveStatus.Add(statusEffect);
                                            statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                        }
                                        else
                                        {
                                            statusResist = "Resisted";
                                        }
                                    }
                                }
                                if (Enemy3.Enemyslotted)
                                {
                                    Enemy3.Hp -= damage;
                                    if (StatusID != 0)
                                    {
                                        if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                        {
                                            StatusEffect statusEffect = new StatusEffect();
                                            statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                            Enemy1.ActiveStatus.Add(statusEffect);
                                            statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                        }
                                        else
                                        {
                                            statusResist = "Resisted";
                                        }
                                    }
                                }
                                Debug.Log("dmg: " + damage);
                                Debug.Log("EHP: " + target.Hp);
                            }
                            else if (Hitall)
                            {
                                //Add flow
                                character.Flow += 1 + Flowbonus;

                                //Deal damage
                                if (Enemy1.Enemyslotted)
                                {
                                    Enemy1.Hp -= damage;
                                    if (StatusID != 0)
                                    {
                                        if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                        {
                                            StatusEffect statusEffect = new StatusEffect();
                                            statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                            Enemy1.ActiveStatus.Add(statusEffect);
                                            statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                        }
                                        else
                                        {
                                            statusResist = "Resisted";
                                        }
                                    }
                                }
                                if (Enemy2.Enemyslotted)
                                {
                                    Enemy2.Hp -= damage;
                                    if (StatusID != 0)
                                    {
                                        if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                        {
                                            StatusEffect statusEffect = new StatusEffect();
                                            statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                            Enemy1.ActiveStatus.Add(statusEffect);
                                            statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                        }
                                        else
                                        {
                                            statusResist = "Resisted";
                                        }
                                    }
                                }
                                if (Enemy3.Enemyslotted)
                                {
                                    Enemy3.Hp -= damage;
                                    if (StatusID != 0)
                                    {
                                        if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                        {
                                            StatusEffect statusEffect = new StatusEffect();
                                            statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                            Enemy1.ActiveStatus.Add(statusEffect);
                                            statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                        }
                                        else
                                        {
                                            statusResist = "Resisted";
                                        }
                                    }
                                }
                                Debug.Log("dmg: " + damage);
                                Debug.Log("EHP: " + target.Hp);
                            }

                            else if (target == GameObject.Find("Enemy1").GetComponent<Enemy>() || target == GameObject.Find("Enemy2").GetComponent<Enemy>() || target == GameObject.Find("Enemy3").GetComponent<Enemy>())
                            {
                                //Add flow
                                character.Flow += 1 + Flowbonus;

                                //Deal damage
                                target.Hp -= damage;
                                if (StatusID != 0)
                                {
                                    if (Random.Range(0.0f, 100.0f) <= StatusChance + character.Flowstatuschance)
                                    {
                                        StatusEffect statusEffect = new StatusEffect();
                                        statusEffect.ListStatusID = StatusID; statusEffect.ListStatusStrenght = StatusStrenght; statusEffect.ListStatusDuration = StatusDuration;
                                        Enemy1.ActiveStatus.Add(statusEffect);
                                        statusResist = IDsorter.GetStatusID(statusEffect.ListStatusID);
                                    }
                                    else
                                    {
                                        statusResist = "Resisted";
                                    }
                                }
                                Debug.Log("dmg: " + damage);
                                Debug.Log("EHP: " + target.Hp);
                            }
                            #endregion

                            //when done:
                            playercanact = false;
                            playerhasacted = false;
                            combatanimator.AnimateCombat(character, target, character.gameObject, target.gameObject, true, damage, statusResist);
                            turnnum++;
                        }
                        else
                        {
                            Debug.Log("Miss");
                            playercanact = false;
                            playerhasacted = false;
                            combatanimator.AnimateCombat(character, target, character.gameObject, target.gameObject, false, damage, statusResist);
                            turnnum++;
                        }
                    }
                    character.hasTurn = false;
                }

                //Handle Enemy
                else
                {
                    if (time <= 0f)
                    {
                        if (CombatOrder.ElementAt(turnnum).Key == "Enemy1")
                        {
                            enemyintrun = GameObject.Find("Enemy1").GetComponent<Enemy>();
                        }
                        else if (CombatOrder.ElementAt(turnnum).Key == "Enemy2")
                        {
                            enemyintrun = GameObject.Find("Enemy2").GetComponent<Enemy>();
                        }
                        else if (CombatOrder.ElementAt(turnnum).Key == "Enemy3")
                        {
                            enemyintrun = GameObject.Find("Enemy3").GetComponent<Enemy>();
                        }

                        Debug.Log("Enemyturn.-------------");
                        if (enemyintrun.Dazed)
                        {
                            enemyintrun.CheckStatus();
                            Debug.Log(enemyintrun + " is dazed ------------------------------------");
                        }
                        else
                        {
                            enemyintrun.CheckStatus();
                            //Enemy AI
                            enemyintrun.statustokenHandler.UpdateTokens();

                            aihandler.AIability(enemyintrun);
                            enemyintrun.hasTurn = false;
                        }
                    }
                    else
                    {
                        time -= Time.deltaTime;
                    }
                }
            }
        }
        else
        {
            //If all turns acted then next round
            melodyhandler.NewMelody(Gamedata.red, Gamedata.blue, Gamedata.yellow, Gamedata.green);
            round++;
            roundtext.text = "Round " + round;
            NewOrder();
            turnTokenManager.UpdateTokens();
        }
    }

    private void NewOrder()
    {
        CombatOrder.Clear();   
        CombatMembers.Clear();
        turnnum = 0;

        //Add characters
        if (Character1.Characterslotted)
        {
            CombatMembers.Add("Character1", (Random.Range(0, 8) + Character1.Speed));
        }
        if (Character2.Characterslotted)
        {
            CombatMembers.Add("Character2", (Random.Range(0, 8) + Character2.Speed));
        }
        if (Character3.Characterslotted)
        {
            CombatMembers.Add("Character3", (Random.Range(0, 8) + Character3.Speed));
        }

        //Add enemies
        if (Enemy1.Enemyslotted)
        {
            CombatMembers.Add("Enemy1", (Random.Range(0, 8) + Enemy1.Speed));
        }
        if (Enemy2.Enemyslotted)
        {
            CombatMembers.Add("Enemy2", (Random.Range(0, 8) + Enemy2.Speed));
        }
        if (Enemy3.Enemyslotted)
        {
            CombatMembers.Add("Enemy3", (Random.Range(0, 8) + Enemy3.Speed));
        }

        foreach(KeyValuePair<string,int> len in CombatMembers.OrderBy(key => key.Value))
        {
            CombatOrder.Add(len.Key, len.Value);
        }

        foreach (var member in CombatOrder)
        {
            if (member.Key == "Character1" || member.Key == "Character2" || member.Key == "Character3")
            {
                GameObject.Find(member.Key).GetComponent<Character>().hasTurn = true;
            }
            else
            {
                GameObject.Find(member.Key).GetComponent<Enemy>().hasTurn = true;
            }
        }
    }

    public void AbilityUsed(string Color, string Name,int Mindmg,int Maxdmg,float Hitchance,int StatusID,float StatusChance,int StatusStrenght,int StatusDuration,int Flowbonus,bool Hitrank1,bool Hitrank2,bool Hitrank3,bool Hit1and2,bool Hit2and3,bool Hitall)
    {
        Select_target.SetActive(true);
        //Transfer data
        this.Color = Color;

        this.Name = Name;
        this.Mindmg = Mindmg;
        this.Maxdmg = Maxdmg;
        this.Hitchance = Hitchance;
        this.StatusID = StatusID;
        this.StatusChance = StatusChance;
        this.StatusStrenght = StatusStrenght;
        this.StatusDuration = StatusDuration;
        this.Flowbonus = Flowbonus;

        this.Hitrank1 = Hitrank1;
        this.Hitrank2 = Hitrank2;
        this.Hitrank3 = Hitrank3;

        this.Hit1and2 = Hit1and2;
        this.Hit2and3 = Hit2and3;
        this.Hitall = Hitall;

        if (Hitrank1 == true)
        {
            Canhit1.SetActive(true);
        }
        if (Hitrank2 == true)
        {
            Canhit2.SetActive(true);
        }
        if (Hitrank3 == true)
        {
            Canhit3.SetActive(true);
        }

        abilityExplanation.UpdateAbilityInfo(this.Hit1and2, this.Hit2and3, this.Hitall, this.Hitrank1, this.Hitrank2, this.Hitrank3, this.Name, this.Mindmg, this.Maxdmg, this.Hitchance, this.StatusID, this.StatusChance, this.StatusStrenght, this.StatusDuration);
    }

    public void UpdateResouces()
    {
        GameObject[] resources = GameObject.FindGameObjectsWithTag("CombatResource");
        foreach (GameObject resource in resources)
        {
            resource.GetComponent<Resourceupdater>().UpdateResources();
        }
    }


}
