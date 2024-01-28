using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Enemychosen : MonoBehaviour
{
    Combathandler combathandler;

    private void Awake()
    {
        combathandler = GameObject.Find("Combathandler").GetComponent<Combathandler>();
    }

    private void OnMouseDown()
    {
        combathandler.playerhasacted = true;
        if (gameObject.name == "Canhit1")
        {
            combathandler.target = GameObject.Find("Enemy1").GetComponent<Enemy>();
        }
        else if (gameObject.name == "Canhit2")
        {
            combathandler.target = GameObject.Find("Enemy2").GetComponent<Enemy>();
        }
        else if (gameObject.name == "Canhit3")
        {
            combathandler.target = GameObject.Find("Enemy3").GetComponent<Enemy>();
        }

        //Hide all shown components
        if(combathandler.Hitrank1)
        {
            GameObject.Find("Canhit1").SetActive(false);
        }
        if (combathandler.Hitrank2)
        {
            GameObject.Find("Canhit2").SetActive(false);
        }
        if (combathandler.Hitrank3)
        {
            GameObject.Find("Canhit3").SetActive(false);
        }
        combathandler.Select_target.SetActive(false);
    }
}
