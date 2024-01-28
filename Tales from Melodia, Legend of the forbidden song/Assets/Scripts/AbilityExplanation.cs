using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityExplanation : MonoBehaviour
{
    [SerializeField] private Sprite Can;
    [SerializeField] private Sprite Cannot;
    [SerializeField] private Sprite CanJoint;
    [SerializeField] private Sprite CannotJoint;

    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    [SerializeField] private GameObject joint1;
    [SerializeField] private GameObject joint2;


    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI DamageText;
    [SerializeField] private TextMeshProUGUI HitChanceText;
    [SerializeField] private TextMeshProUGUI StatusText;
    [SerializeField] private TextMeshProUGUI StatusChanceText;
    [SerializeField] private TextMeshProUGUI StatusDamageText;
    [SerializeField] private TextMeshProUGUI StatusDamageDurationText;

    public void UpdateAbilityInfo(bool Hit1and2, bool Hit2and3, bool Hitall, bool Hitrank1, bool Hitrank2, bool Hitrank3, string Name, int MinDamage, int MaxDamage, float HitChance, int Status, float StatusChance, int StatusDamage, int StatusDuration)
    {
        NameText.text = Name;
        DamageText.text = MinDamage + "-" + MaxDamage;
        HitChanceText.text = (HitChance) + "%";
        StatusChanceText.text = StatusChance.ToString() + "%";
        StatusDamageText.text = StatusDamage.ToString();
        StatusDamageDurationText.text = StatusDuration.ToString();

        switch (Status)
        {
            case 0:
                StatusChanceText.text = "-";
                StatusDamageText.text = "-";
                StatusDamageDurationText.text = "-";
                StatusText.text = "No Status";
                break;
            case 1:
                StatusText.text = "Daze";
                break;
            case 2:
                StatusText.text = "Voltage";
                break;
        }

        #region slots
        slot1.GetComponent<SpriteRenderer>().sprite = Cannot;
        slot2.GetComponent<SpriteRenderer>().sprite = Cannot;
        slot3.GetComponent<SpriteRenderer>().sprite = Cannot;
        joint1.GetComponent<SpriteRenderer>().sprite = CannotJoint;
        joint2.GetComponent<SpriteRenderer>().sprite = CannotJoint;

        if (Hit1and2)
        {
            slot1.GetComponent<SpriteRenderer>().sprite = Can;
            slot2.GetComponent<SpriteRenderer>().sprite = Can;
            joint1.GetComponent<SpriteRenderer>().sprite = CanJoint;
        }
        else if (Hit2and3)
        {
            slot2.GetComponent<SpriteRenderer>().sprite = Can;
            slot3.GetComponent<SpriteRenderer>().sprite = Can;
            joint2.GetComponent<SpriteRenderer>().sprite = CanJoint;
        }
        else if (Hitall)
        {
            slot1.GetComponent<SpriteRenderer>().sprite = Can;
            slot2.GetComponent<SpriteRenderer>().sprite = Can;
            slot3.GetComponent<SpriteRenderer>().sprite = Can;
            joint1.GetComponent<SpriteRenderer>().sprite = CanJoint;
            joint2.GetComponent<SpriteRenderer>().sprite = CanJoint;
        }
        else if (Hitrank1 || Hitrank2 || Hitrank3)
        {
            if (Hitrank1)
            {
                slot1.GetComponent<SpriteRenderer>().sprite = Can;
            }
            else if (Hitrank2)
            {
                slot2.GetComponent<SpriteRenderer>().sprite = Can;
            }
            else if (Hitrank3)
            {
                slot3.GetComponent<SpriteRenderer>().sprite = Can;
            }
        }
        #endregion
    }
}
