using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScript : MonoBehaviour
{
    public Text thisText;

    public float poly;
    
    
    private float count;
    void Start()
    {
        thisText = GetComponent<Text>();
        count = 0;

    }

    public void AddCount()
    {
     
        count = (count + 1) % poly;
    }

    public float getCount()
    {
        return count + 1;
    }
    // Update is called once per frame
    void Update()
    {
        thisText.text = "" + (count+1);
    }

    public void updateGameState(float gsPoly)
    {
        count = 0;
        poly = gsPoly;
    }
}
