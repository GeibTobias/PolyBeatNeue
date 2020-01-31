using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshPro thisText;

    private float totalScore;
    private bool hittable = true;
    private float displayScore;
    private float internalScore;

    public PlayerScript player;

    public TextMeshPro finalText;

    public Light primlight;
    public Light secLight;
    void Start()
    {
        //thisText = GetComponent<Text>();
        totalScore = 0;
    }

    public void AddScore(float score)
    {
        /*
        if (hittable)
        {
            float round_score = Mathf.Floor(score * 100.0f);
            totalScore += round_score;
        }
        hittable = false;
*/
    }

    public void SetHittable()
    {
        /*
        hittable = true;
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (SongTiming.hasStarted())
        {
            internalScore += totalScore;
            
        }
        totalScore = player.displaySpeed;
        displayScore = Mathf.FloorToInt(totalScore);
        string scoreoffset = "";
        displayScore = Mathf.Max(0,Mathf.Min(displayScore, 1000));
        if (displayScore < 10)
        {
            scoreoffset = "000";
        } else if (displayScore < 100)
        {
            scoreoffset = "00";
        } else if (displayScore < 1000)
        {
            scoreoffset = "0";
        }

        primlight.intensity = displayScore / 100;
        secLight.intensity = primlight.intensity;
       thisText.text = scoreoffset + displayScore;
    }

    public void onFinished()
    {
        float ds = Mathf.FloorToInt(internalScore / 1000);
        //float ds = internalScore;
        finalText.text = "GAME OVER \n Highscore: \n" + ds;
    }
    
}
