using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AIhandler : MonoBehaviour
{
    Combathandler combathandler;

    private List<string> ChooseAbility = new List<string>();

    private List<Character> Listrandomizer = new List<Character>();
    private Dictionary<Character, int> Dictrandomizer = new Dictionary<Character, int>();
    private Dictionary<Character, int> DictOrdered = new Dictionary<Character, int>();

    private float hit;

    private bool attackhit;

    void Awake()
    {
        combathandler = GameObject.Find("Combathandler").GetComponent<Combathandler>();
    }

    public void AIability(Enemy enemy)
    {
        ChooseAbility.Clear();
        if (enemy.Enemynumber == 1)
        {
            for (int i = 0; i < Gamedata.Enemy1.AIability1.Probability; i++)
            {
                ChooseAbility.Add("ability 1");
            }
            for (int i = 0; i < Gamedata.Enemy1.AIability2.Probability; i++)
            {
                ChooseAbility.Add("ability 2");
            }
            for (int i = 0; i < Gamedata.Enemy1.AIability3.Probability; i++)
            {
                ChooseAbility.Add("ability 3");
            }
            for (int i = 0; i < Gamedata.Enemy1.AIability4.Probability; i++)
            {
                ChooseAbility.Add("ability 4");
            }

            ExecuteAbility(ChooseAbility[Random.Range(0, 20)], enemy);
        }
    }

    private bool CheckHit(Enemy enemy, Character target)
    {
        if (Random.Range(0.0f, 100.0f) <= hit-target.Dodge)
        {
            attackhit = true;
            return true;
        }
        else
        {
            attackhit = false;
            return false;
        }
    }

    public void ExecuteAbility(string ability, Enemy enemy)
    {
        Character target = null;
        int damage = 0;
        ChooseAbility.Clear();
        Listrandomizer.Clear();
        Dictrandomizer.Clear();
        DictOrdered.Clear();
        switch (enemy.AI)
        {
            case 1: //in case 1: 1 random, 2 with most flow
                switch (ability)
                {
                    case "ability 1":
                        //get random target
                        if (combathandler.Character1.Characterslotted)
                        {
                            Listrandomizer.Add(combathandler.Character1);
                        }
                        if (combathandler.Character2.Characterslotted)
                        {
                            Listrandomizer.Add(combathandler.Character2);
                        }
                        if (combathandler.Character3.Characterslotted)
                        {
                            Listrandomizer.Add(combathandler.Character3);
                        }
                        hit = enemy.hit1;
                        target = Listrandomizer[Random.Range(0, Listrandomizer.Count)];
                        damage = Random.Range(enemy.mindmg1, enemy.maxdmg1 + 1);
                        if (CheckHit(enemy, target))
                        {
                            target.Hp -= damage;
                            target.Flow -= enemy.flowreduction1;
                        }
                        if (target.Flow < 0)
                        {
                            target.Flow = 0;
                        }
                        Listrandomizer.Clear();
                        Debug.Log("Ability1 used");
                        break;

                    case "ability 2":
                        if (combathandler.Character1.Characterslotted)
                        {
                            Dictrandomizer.Add(combathandler.Character1, combathandler.Character1.Flow);
                        }
                        if (combathandler.Character2.Characterslotted)
                        {
                            Dictrandomizer.Add(combathandler.Character2, combathandler.Character2.Flow);
                        }
                        if (combathandler.Character3.Characterslotted)
                        {
                            Dictrandomizer.Add(combathandler.Character3, combathandler.Character3.Flow);
                        }
                        foreach (KeyValuePair<Character, int> len in Dictrandomizer.OrderBy(key => key.Value))
                        {
                            DictOrdered.Add(len.Key, len.Value);
                        }
                        hit = enemy.hit2;
                        target = DictOrdered.Keys.ElementAt(DictOrdered.Count()-1);
                        //add check if 2 targets have same flow
                        damage = Random.Range(enemy.mindmg2, enemy.maxdmg2 + 1);
                        if (CheckHit(enemy, target))
                        {
                            target.Hp -= damage;
                            target.Flow -= enemy.flowreduction2;
                        }
                        if (target.Flow < 0)
                        {
                            target.Flow = 0;
                        }
                        Dictrandomizer.Clear();
                        DictOrdered.Clear();
                        Debug.Log("Ability2 used");
                        break;

                    case "ability 3":

                        break;

                    case "ability 4":

                        break;
                }
                break;
        }

        combathandler.combatanimator.AnimateCombat(target, enemy, enemy.gameObject, target.gameObject, attackhit, damage, null);
        combathandler.turnnum += 1;
        Debug.Log("Enemyacted");
    }
}
