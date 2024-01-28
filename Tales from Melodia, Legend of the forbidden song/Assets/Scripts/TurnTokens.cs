using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TurnTokens : MonoBehaviour
{
    [SerializeField] private GameObject turnToken;

    [SerializeField] private Combathandler combathandler;

    private List<GameObject> initializedTokens = new List<GameObject>();

    public void UpdateTokens() //Set combathandler removal type combat list
    {
        foreach (GameObject initToken in initializedTokens)
        {
            Destroy(initToken);
        }
        initializedTokens.Clear();
        float val = 0;

        foreach (var entry in combathandler.CombatOrder)
        {
            float xPos;
            GameObject obj = GameObject.Find(entry.Key);
            if (obj != null)
            {
                if (obj.GetComponent<Enemy>() != null)
                {
                    xPos = obj.GetComponent<Enemy>().transform.position.x;
                }
                else
                {
                    xPos = obj.GetComponent<Character>().transform.position.x;
                }
                foreach (GameObject previoustoken in initializedTokens)
                {
                    if (xPos == previoustoken.transform.position.x)
                    { // GLitch with token movings
                        previoustoken.transform.position = new Vector3(previoustoken.transform.position.x - 0.25f * val, previoustoken.transform.position.y, previoustoken.transform.position.z);
                        val += 1;
                        xPos += 0.25f * val;
                    }
                    
                }
                val = 0;
                initializedTokens.Add(Instantiate(turnToken, new Vector3(xPos, -1.95f, 0f), new Quaternion(0, 0, 0, 0)));
            }
        }
    }
}
