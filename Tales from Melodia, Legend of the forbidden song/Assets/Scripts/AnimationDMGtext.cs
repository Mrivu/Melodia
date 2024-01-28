using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationDMGtext : MonoBehaviour
{
    [SerializeField] private GameObject textField;

    public void ChangeText(string text, bool visibility, Color color)
    {
        if (textField.activeSelf != visibility)
        {
            textField.SetActive(textField.activeSelf ? false : true);
        }
        if (text != null)
        {
            textField.GetComponentInChildren<TextMeshProUGUI>().text = text;
            textField.GetComponentInChildren<TextMeshProUGUI>().color = color;
        }
    }
}
