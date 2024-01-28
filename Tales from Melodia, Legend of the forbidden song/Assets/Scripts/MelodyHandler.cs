using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MelodyHandler : MonoBehaviour
{
    [SerializeField] Sprite red;
    [SerializeField] Sprite blue;
    [SerializeField] Sprite yellow;
    [SerializeField] Sprite green;

    [SerializeField] GameObject infobar;

    private Sprite result;

    private string currentColor;

    private List<Sprite> Melodies = new List<Sprite>();

    [SerializeField] private Slider melodyvalue;

    public float modifier = 0;

    //0-10, 0: -50% dmg and 10: +50% dmg

    private void Awake()
    {
        NewMelody(Gamedata.red, Gamedata.blue, Gamedata.yellow, Gamedata.green);
        melodyvalue.maxValue = 10;
        melodyvalue.minValue = 0;
        melodyvalue.value = 5;
    }

    public void ChangeMelody(string color)
    {
        if (color == currentColor || color == "prism")
        {
            melodyvalue.value += 1;
        }
        else
        {
            melodyvalue.value -= 4;
        }
        if (melodyvalue.value < 0)
        {
            melodyvalue.value = 0;
        }
        else if (melodyvalue.value > 11)
        {
            melodyvalue.value = 10;
        }

        modifier = (melodyvalue.value - 5) / 10;
    }

    public void NewMelody(bool red, bool blue, bool yellow, bool green)
    {
        Melodies.Clear();
        if (red)
        {
            Melodies.Add(this.red);
        }
        if (blue)
        {
            Melodies.Add(this.blue);
        }
        if(yellow)
        {
            Melodies.Add(this.yellow);
        }
        if (green)
        {
            Melodies.Add(this.green);
        }
        result = Melodies[Random.Range(0, Melodies.Count)];
        gameObject.GetComponent<SpriteRenderer>().sprite = result;
        if (result == this.red)
        {
            currentColor = "red";
        }
        else if (result == this.blue)
        {
            currentColor = "blue";
        }
        else if (result == this.yellow)
        {
            currentColor = "yellow";
        }
        else if (result == this.green)
        {
            currentColor = "green";
        }
    }

    private void OnMouseOver()
    {
        infobar.SetActive(true);
        infobar.GetComponent<InfoBar>().melody.SetActive(true);
        ChangeValues();
    }

    private void OnMouseExit()
    {
        infobar.GetComponent<InfoBar>().melody.SetActive(false);
        infobar.SetActive(false);
    }

    private void ChangeValues()
    {
        infobar.GetComponent<InfoBar>().melodymodifier = modifier;
    }
}
