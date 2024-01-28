using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatustokenHandler : MonoBehaviour
{
    Combathandler combathandler;

    Enemy enemy;

    public GameObject[] AllTokens = null;

    [SerializeField] GameObject DazeToken;
    [SerializeField] GameObject VoltageToken;

    public List<GameObject> ListedTokens = new List<GameObject>();
    public List<GameObject> ShowTokens = new List<GameObject>();
    public List<GameObject> CurrentTokens = new List<GameObject>();

    private void Awake()
    {
        combathandler = GameObject.Find("Combathandler").GetComponent<Combathandler>();
        AllTokens = GameObject.FindGameObjectsWithTag("StatusToken");
        enemy = gameObject.GetComponent<Enemy>();

        foreach (GameObject token in AllTokens)
        {
            ListedTokens.Add(token);
        }

        //Chek enemy status list
    }


    public void UpdateTokens()
    {
        int val = 0;
        //Get all tokens and destroy old ones
        ShowTokens.Clear();
        foreach (GameObject gameObject in CurrentTokens)
        {
            Destroy(gameObject);
        }
        CurrentTokens.Clear();

        if (enemy.Enemyslotted)
        {
            if (enemy.ActiveStatus != null)
            {
                foreach (Enemy.StatusEffect status in enemy.ActiveStatus)
                {
                    //Generate new ones
                    if (status.ListStatusID == 1)
                    {
                        DazeToken.GetComponent<TokenScript>().GetTokenInfo(status.ListStatusStrenght, status.ListStatusDuration);
                        ShowTokens.Add(DazeToken);
                    }
                    else if (status.ListStatusID == 2)
                    {
                        VoltageToken.GetComponent<TokenScript>().GetTokenInfo(status.ListStatusStrenght, status.ListStatusDuration);
                        ShowTokens.Add(VoltageToken);
                    }
                }

                foreach (GameObject token in ShowTokens)
                {
                    val = 0;
                    //Shift positions
                    foreach (GameObject previoustoken in CurrentTokens)
                    {
                        val += 1;
                        previoustoken.transform.position = new Vector3(previoustoken.transform.position.x - 0.25f, previoustoken.transform.position.y, previoustoken.transform.position.z);
                        //2.45 mid, 2,2 and 2,7
                    }
                    CurrentTokens.Add(Instantiate(token, new Vector3(enemy.transform.position.x - 0.05f + 0.25f * val, -0.64f, 0f), new Quaternion(0f, 0f, 0f, 0f)));
                }
                if (CurrentTokens != null)
                {
                    foreach (GameObject token in CurrentTokens)
                    {
                        token.SetActive(true);
                    }
                }
            }

        }
    }
}

