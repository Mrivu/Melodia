using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class InfoBar : MonoBehaviour
{
    [SerializeField] Camera sceneCamera;

    public GameObject token;
    public GameObject melody;

    [SerializeField] TextMeshProUGUI strengthtext;
    [SerializeField] TextMeshProUGUI timetext;

    [SerializeField] TextMeshProUGUI melodytext;

    public int strength = 0;
    public int time = 0;

    public float melodymodifier = 0;

    private Vector3 Pos = new Vector3 (0, 0, 0);

    private void Awake()
    {
        token.SetActive(false);
        melody.SetActive(false);
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            Pos = sceneCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.96f, 0.32f, 0);
            Pos.z = 0;
            gameObject.transform.position = Pos;
            if (token.activeSelf)
            {
                strengthtext.text = strength.ToString();
                timetext.text = time.ToString();
            }
            if (melody.activeSelf)
            {
                melodytext.text = "Damage modifier: " + (melodymodifier*100).ToString() + "%";
            }
        }
    }
}
