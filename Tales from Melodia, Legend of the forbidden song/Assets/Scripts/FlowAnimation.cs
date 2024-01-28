using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class FlowAnimation : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(true);
    }
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
