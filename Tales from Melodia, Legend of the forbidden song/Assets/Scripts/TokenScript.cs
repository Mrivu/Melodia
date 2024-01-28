using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    [SerializeField] GameObject infobar;

    public int s;
    public int t;

    public void GetTokenInfo(int strenght, int time)
    {
        s = strenght;
        t = time;
    }

    private void OnMouseOver()
    {
        infobar.SetActive(true);
        infobar.GetComponent<InfoBar>().token.SetActive(true);
        ChangeValues();
    }

    private void OnMouseExit()
    {
        infobar.GetComponent<InfoBar>().token.SetActive(false);
        infobar.SetActive(false);
    }

    private void ChangeValues()
    {
        infobar.GetComponent<InfoBar>().strength = s;
        infobar.GetComponent<InfoBar>().time = t;
    }
}
