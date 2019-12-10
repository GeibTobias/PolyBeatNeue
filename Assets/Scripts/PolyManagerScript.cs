using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyManagerScript : MonoBehaviour
{

    public float polyL;
    public float polyR;
    public float bpm;
    public float quaver;

    public AudioSource audioLeft;
    public AudioSource audioRight;
    
    private GameObject bbBlue;
    private GameObject bbRed;
    private BallScript bsBlue;
    private BallScript bsRed;

    private GameObject canvasBlue;
    private GameObject canvasRed;
    private CountScript csBlue;
    private CountScript csRed;

    private GameObject progIndBlue;
    private GameObject progIndRed;
    private ProgScript psBlue;
    private ProgScript psRed;

    private float prevPolyL;
    private float prevPolyR;
    private float prevBpm;

    public float timerL;
    public float timerR;
    public float polyLTime;
    public float polyRTime;


    private bool playerHasTriggerL;
    private bool playerHasTriggerR;

    private int counterL;
    private int counterR;
    
    
    public 
    // Start is called before the first frame update
    void Start()
    {
        bbBlue = GameObject.Find("BeatBallBlue");
        bbRed = GameObject.Find("BeatBallRed");

        bsBlue = bbBlue.GetComponent<BallScript>();
        bsRed = bbRed.GetComponent<BallScript>();
        
        canvasBlue = GameObject.Find("CanvasBlue");
        canvasRed = GameObject.Find("CanvasRed");

        csBlue = canvasBlue.GetComponentInChildren<CountScript>();
        csRed = canvasRed.GetComponentInChildren<CountScript>();

        progIndBlue = GameObject.Find("ProgIndicatorBlue");
        progIndRed = GameObject.Find("ProgIndicatorRed");

        psBlue = progIndBlue.GetComponent<ProgScript>();
        psRed = progIndRed.GetComponent<ProgScript>();

        prevPolyL = polyL;
        prevPolyL = polyR;
        prevBpm = bpm;

        timerL = 0;
        timerR = 0;

        polyLTime = computeTimer(polyL);
        polyRTime = computeTimer(polyR);

        counterL = 0;
        counterR = 0;

        playerHasTriggerL = false;
        playerHasTriggerR = false;
        
        updateGameState();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    
        if (!playerHasTriggerL & OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f)
        {
            onTriggerLeft();
        }
    
        if (!playerHasTriggerR & OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f)
        {
            onTriggerRight();
        }

        if (timerL > polyLTime)
        {
            counterL = (counterL + 1) % 2;
            if (counterL == 1)
            {
                if (!playerHasTriggerL)
                {
                    csBlue.AddCount();
                    psBlue.onTrigger();
                }
                playerHasTriggerL = false;
                csBlue.AddCount();
                psBlue.onTrigger();
                audioLeft.Play();
            }
            bsBlue.onTimer(false);
            timerL -= polyLTime;
        }

        if (timerR > polyRTime)
        {
            counterR = (counterR + 1) % 2;
            if (counterR == 1)
            {
                if (!playerHasTriggerR)
                {
                    csRed.AddCount();
                    psRed.onTrigger();
                }
                playerHasTriggerR = false;
                csRed.AddCount();
                psRed.onTrigger();
                audioRight.Play();
            }
            bsRed.onTimer(false);
            timerR -= polyRTime;
        }
        
        if (checkChanged())
        {
            polyLTime = computeTimer(polyL);
            polyRTime = computeTimer(polyR);
            timerL = 0;
            timerR = 0;
            counterL = 0;
            counterR = 0;
            playerHasTriggerL = true;
            playerHasTriggerR = true;
            updateGameState();    
        }
        
        
        timerL += Time.deltaTime;
        timerR += Time.deltaTime;
    }

    private void updateGameState()
    {
        bsBlue.updateGameState(polyL,bpm);
        bsRed.updateGameState(polyR,bpm);

        csBlue.updateGameState(polyL);
        csRed.updateGameState(polyR);

        psBlue.updateGameState(polyL);
        psRed.updateGameState(polyR);

    }

    private bool checkChanged()
    {
        bool isChanged = false;
        if (prevBpm != bpm)
        {
            isChanged = true;
            prevBpm = bpm;
        }
        if (prevPolyL != polyL)
        {
            isChanged = true;
            prevPolyL = polyL;
        }
        if (prevPolyR != polyR)
        {
            isChanged = true;
            prevPolyR = polyR;
        }

        return isChanged;
    }

    private float computeTimer(float poly)
    {
        float b = 60.0f / bpm;
        float normalized_b = b * quaver;
        return normalized_b / poly;
    }

    
    private void onTriggerLeft()
    {

        audioLeft.Play();
        csBlue.AddCount();
        psBlue.onTrigger();
        OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.LTouch);

        playerHasTriggerL = true;
    }
    
    private void onTriggerRight()
    {
        
        audioRight.Play();
        csRed.AddCount();
        psRed.onTrigger();
        OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.RTouch);

        playerHasTriggerR = true;
    }
}
