using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static Gamedata;

public class CombatAnimator : MonoBehaviour
{
    [SerializeField] private GameObject bg;

    private Combathandler combathandler;

    private GameObject attacker;
    private GameObject defender;

    public GameObject statusText;

    [SerializeField] TurnTokens turnTokenManager;

    private float time;
    private bool timer = false;

    private bool attacked = false;

    private Vector3 characterpodiumpos;
    private Vector3 enemypodiumpos;

    private Character character;
    private Enemy enemy;

    private InfoBar infoBar = null;

    private bool hit;
    private int dmg;
    private string statusResist;

    private void Awake()
    {
        combathandler = GameObject.Find("Combathandler").GetComponent<Combathandler>();
        infoBar = GameObject.Find("InfoBar").GetComponent<InfoBar>();
    }

    public void AnimateCombat(Character character, Enemy enemy, GameObject attacker, GameObject defender, bool hit, int dmg, string statusResist)
    {
        infoBar.token.SetActive(false);
        infoBar.gameObject.SetActive(false);
        combathandler.OngoingAnimation = true;
        attacked = false;
        bg.SetActive(true);

        character.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
        enemy.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;

        this.attacker = attacker;
        this.defender = defender;
        this.character = character;
        this.enemy = enemy;
        this.hit = hit;
        this.dmg = dmg;
        this.statusResist = statusResist;

        characterpodiumpos = character.gameObject.transform.position;
        enemypodiumpos = enemy.gameObject.transform.position;

        character.gameObject.transform.position = new Vector3(-4, character.gameObject.transform.position.y, character.gameObject.transform.position.z);
        enemy.gameObject.transform.position = new Vector3(4, enemy.gameObject.transform.position.y, enemy.gameObject.transform.position.z);

        if (CheckFlowStatus(attacker))
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().attackingFlow;
        }
        else
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().attacking;
        }

        time = 1.5f;
        timer = true;
    }

    private void Update()
    {

        // animation 
        if (timer)
        {
            if (!attacked && time <= 0.5f)
            {
                DoAttack();
                attacked = true;
            }
            if (time <= 0f)
            {
                TimerEnd();
                timer = false;
            }
            else
            {
                time -= Time.deltaTime;
                character.gameObject.transform.position = new Vector3(character.gameObject.transform.position.x + Time.deltaTime, character.gameObject.transform.position.y, character.gameObject.transform.position.z);
                enemy.gameObject.transform.position = new Vector3(enemy.gameObject.transform.position.x - Time.deltaTime, enemy.gameObject.transform.position.y, enemy.gameObject.transform.position.z);
            }
        }
    }
    private void DoAttack()
    {
        if (CheckFlowStatus(attacker))
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().attack1Flow;
        }
        else
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().attack1;
        }

        if (hit)
        {
            string statusText = null;
            if (statusResist != null)
            {
                statusText = " " + statusResist;
            }
            defender.GetComponent<AnimationDMGtext>().ChangeText("-" + dmg.ToString() + statusText, true, Color.red);

            if (CheckFlowStatus(defender))
            {
                defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().hitFlow;
            }
            else
            {
                defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().hit;
            }

            if (defender.GetComponent<AnimationData>().character != null)
            {
                if (defender.GetComponent<AnimationData>().character.Hp <= 0)
                {
                    if (CheckFlowStatus(defender))
                    {
                        defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().killedFlow;
                    }
                    else
                    {
                        defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().killed;
                    }
                }
            }
            else if (defender.GetComponent<AnimationData>().enemy != null)
            {
                if (defender.GetComponent<AnimationData>().enemy.Hp <= 0)
                {
                    if (CheckFlowStatus(defender))
                    {
                        defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().killedFlow;
                    }
                    else
                    {
                        defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().killed;
                    }
                }
            }

        }
        else
        {
            defender.GetComponent<AnimationDMGtext>().ChangeText("Missed", true, Color.white);
            if (CheckFlowStatus(defender))
            {
                defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().dodgeFlow;
            }
            else
            {
                defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().dodge;
            }
        }

    }

    private void TimerEnd()
    {
        character.transform.position = characterpodiumpos;
        enemy.transform.position = enemypodiumpos;

        if (CheckFlowStatus(attacker))
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().idleFlow;
        }
        else
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().idle;
        }

        if (CheckFlowStatus(defender))
        {
            defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().idleFlow;
        }
        else
        {
            defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().idle;
        }

        character.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        enemy.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        defender.GetComponent<AnimationDMGtext>().ChangeText(null, false, Color.white);

        combathandler.Enemy1.statustokenHandler.UpdateTokens();
        combathandler.Enemy2.statustokenHandler.UpdateTokens();
        combathandler.Enemy3.statustokenHandler.UpdateTokens();

        bg.SetActive(false);
        combathandler.time = 1.0f;
        combathandler.UpdateResouces();

        if (CheckFlowStatus(attacker))
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().idleFlow;
        }
        else
        {
            attacker.GetComponent<SpriteRenderer>().sprite = attacker.GetComponent<AnimationData>().idle;
        }
        if (CheckFlowStatus(defender))
        {
            defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().idleFlow;
        }
        else
        {
            defender.GetComponent<SpriteRenderer>().sprite = defender.GetComponent<AnimationData>().idle;
        }

        combathandler.OngoingAnimation = false;
        Debug.Log("Over");
    }

    private bool CheckFlowStatus(GameObject target)
    {
        if (target.GetComponent<AnimationData>().IsCharacter)
        {
            if (target.GetComponent<Character>().InFlow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }


    // Add animation text for damage
    // Add enemy ability name before use
    // Fix status token locations

}
