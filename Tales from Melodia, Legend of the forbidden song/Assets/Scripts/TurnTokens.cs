using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TurnTokens : MonoBehaviour
{
    [SerializeField] private GameObject turnToken;

    [SerializeField] private Combathandler combathandler;

    private List<GameObject> initializedTokens = new List<GameObject>();

    public void UpdateTokens() //problem of start offset may lay in animation location during update tokens, set update tpkens earlier
    {
        Debug.Log("Update tokens");
        foreach (GameObject token in initializedTokens)
        {
            Destroy(token);
        }
        initializedTokens.Clear();
        float xPos = 0;
        foreach (KeyValuePair<string, int> len in combathandler.CombatOrder)
        {
            GameObject obj = GameObject.Find(len.Key);
            if (obj != null)
            {
                if (obj.GetComponent<Enemy>() != null)
                {
                    xPos = obj.GetComponent<Enemy>().podiumPosition.x - 1.25f;
                }
                else
                {
                    xPos = obj.GetComponent<Character>().podiumPosition.x + 1.25f;
                }
            }

            GameObject initToken = Instantiate(turnToken, new Vector3(xPos, -1.95f, 0f), new Quaternion(0, 0, 0, 0));
            initializedTokens.Add(initToken);
        }
    }
}
