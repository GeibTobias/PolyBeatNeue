using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text thisText;

    private float totalScore;
    private bool hittable = true;
    void Start()
    {
        thisText = GetComponent<Text>();
        totalScore = 0;
    }

    public void AddScore(float score)
    {
        if (hittable)
        {
            float round_score = Mathf.Floor(score * 100.0f);
            totalScore += round_score;
        }
        hittable = false;

    }

    public void SetHittable()
    {
        hittable = true;
    }
    // Update is called once per frame
    void Update()
    {
        thisText.text = "Score :" + totalScore;
    }
}
