using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text thisText;

    private static float totalScore;
    void Start()
    {
        thisText = GetComponent<Text>();
        totalScore = 0;
    }

    public static void AddScore(float score)
    {
        float round_score = Mathf.Floor(score * 100.0f);
        totalScore += round_score;
    }
    // Update is called once per frame
    void Update()
    {
        thisText.text = "Score :" + totalScore;
    }
}
