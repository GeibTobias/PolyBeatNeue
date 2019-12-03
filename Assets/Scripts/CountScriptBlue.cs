using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScriptBlue : MonoBehaviour
{public Text thisText;

    public float poly;
    
    private float count;
    void Start()
    {
        thisText = GetComponent<Text>();
        count = 1;
    }

    public void AddCount()
    {
     
        count = (count + 1) % poly;
    }
    // Update is called once per frame
    void Update()
    {
        thisText.text = "" + count;
    }
}
