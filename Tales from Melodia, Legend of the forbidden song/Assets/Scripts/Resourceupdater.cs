using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Resourceupdater : MonoBehaviour
{
    [SerializeField] private bool HP;
    [SerializeField] private bool FLOW;
    [SerializeField] private bool CHARACTER;
    [SerializeField] private int NUMBER;

    private bool canflow = false;

    private float time;
    private bool timer = false;

    [SerializeField] TextMeshProUGUI textfield;

    private Combathandler combathandler;

    private Character character;

    private GameObject flowAnimationBG;
    private GameObject flowCircle;
    private GameObject flowCanvas;

    Vector3 podiumPos;

    void Awake()
    {
        combathandler = GameObject.Find("Combathandler").GetComponent<Combathandler>();
        flowAnimationBG = GameObject.Find("FlowActivate");
        flowCircle = GameObject.Find("Circle");
        flowCanvas = GameObject.Find("FlowCanvas");

        canflow = false;

        if (CHARACTER)
        {
            if (NUMBER == 1)
            {
                character = GameObject.Find("Character1").GetComponent<Character>();
            }
            if (NUMBER == 2)
            {
                character = GameObject.Find("Character2").GetComponent<Character>();
            }
            if (NUMBER == 3)
            {
                character = GameObject.Find("Character3").GetComponent<Character>();
            }
        }
    }

    public void UpdateResources()
    {
        if (CHARACTER)
        {
            if (character.FlowDur <= 0 && character.InFlow)
            {
                character.InFlow = false;
                character.Flowdamage = 1f;
                character.Flowhitchance = 0f;
                character.Flowstatuschance = 0f;
                character.FlowDur = 0;
                character.Flow = 0;
            }
            if (HP)
            {
                textfield.text = character.Hp + "/" + character.Maxhp;
            }
            else
            {
                if (character.InFlow)
                {
                    textfield.text = "In flow: " + character.FlowDur;
                }
                else
                {
                    textfield.text = character.Flow + "/" + character.Maxflow;
                    if (character.Flow >= character.Maxflow)
                    {
                        textfield.text = "Enter flow";
                        character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<AnimationData>().idle;
                        canflow = true;
                    }
                }
            }
        }
        else
        {
            if (NUMBER == 1)
            {
                textfield.text = GameObject.Find("Enemy1").GetComponent<Enemy>().Hp + "/" + GameObject.Find("Enemy1").GetComponent<Enemy>().Maxhp;
            }
            if (NUMBER == 2)
            {
                textfield.text = GameObject.Find("Enemy2").GetComponent<Enemy>().Hp + "/" + GameObject.Find("Enemy2").GetComponent<Enemy>().Maxhp;
            }
            if (NUMBER == 3)
            {
                textfield.text = GameObject.Find("Enemy3").GetComponent<Enemy>().Hp + "/" + GameObject.Find("Enemy3").GetComponent<Enemy>().Maxhp;
            }
        }
    }
    private void OnMouseDown()
    {
        // In flow: 125% damage and +30% hit and status chance
        if (canflow && !character.InFlow && FLOW)
        {
            canflow = false;
            character.InFlow = true;
            character.Flowdamage = 1.25f;
            character.Flowhitchance = 30f;
            character.Flowstatuschance = 30f;
            character.FlowDur = 3;
            textfield.text = "In flow: " + character.FlowDur;
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<AnimationData>().idleFlow;
            flowAnimationBG.GetComponent<SpriteRenderer>().enabled = true;
            flowCircle.GetComponent<SpriteRenderer>().enabled = true;
            flowCanvas.GetComponent<Canvas>().enabled = true;
            combathandler.OngoingAnimation = true;
            FlowAnimation(character);
        }
    }

    private void FlowAnimation(Character character)
    {
        podiumPos = character.transform.position;
        character.transform.position = new Vector3(0,-0.3f,0);
        character.GetComponent<SpriteRenderer>().sortingOrder = 8;
        flowAnimationBG.SetActive(true);
        time = 2.0f;
        timer = true;
    }

    private void Update()
    {
        // animation 
        if (timer)
        {
            
            if (time <= 0f)
            {
                TimerEnd();
                timer = false;
            }
            else
            {
                time -= Time.deltaTime;
                GameObject.Find("Circle").transform.Rotate(0, 0, 1.1f*180*Time.deltaTime, Space.Self);
            }
        }
    }

    private void TimerEnd()
    {
        character.GetComponent<SpriteRenderer>().sortingOrder = 1;
        GameObject.Find("Circle").transform.Rotate(0, 0, 0, 0);
        flowAnimationBG.GetComponent<SpriteRenderer>().enabled = false;
        flowCircle.GetComponent<SpriteRenderer>().enabled = false;
        flowCanvas.GetComponent<Canvas>().enabled = false;
        character.transform.position = podiumPos;
        combathandler.OngoingAnimation = false;
    }
}
