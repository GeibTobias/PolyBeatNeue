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
    public AudioSource music;
    
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

    private GameObject gloveL;
    private GameObject gloveR;

    public Material gloveLMat;
    public Material gloveRMat;

    public Material gloveLSelect;
    public Material gloveRSelect;
    
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

    private float adjustTimer;
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

        gloveL = GameObject.Find("Glove_L");
        gloveR = GameObject.Find("Glove_R");
        
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

        adjustTimer = 1;
        
        updateGameState();
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerHasTriggerL)
        {
            gloveL.GetComponent<Renderer>().material = gloveLSelect;
        }
        else
        {
            gloveL.GetComponent<Renderer>().material = gloveLMat;
        }
        
        if (!playerHasTriggerR)
        {
            gloveR.GetComponent<Renderer>().material = gloveRSelect;
        }
        else
        {
            gloveR.GetComponent<Renderer>().material = gloveRMat;
        }
        
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

        if (!playerHasTriggerL & OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f)
        {
            onTriggerLeft();
        }
    
        if (!playerHasTriggerR & OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f)
        {
            onTriggerRight();
        }

        if (timerR > polyRTime & timerL > polyLTime & polyL == 4 & polyR == 3)
        {
            if (!music.isPlaying)
            {
                music.Play();
            }
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

        

        if (adjustTimer == 0 & OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            adjustLeft(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x);
        }
        
        
        if (adjustTimer == 0 & OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            adjustRight(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x);
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
        adjustTimer = Mathf.Max(0, adjustTimer - Time.deltaTime);
    }

    private void updateGameState()
    {
        music.Stop();
        
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
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);

        playerHasTriggerL = true;
    }
    
    private void onTriggerRight()
    {
        
        audioRight.Play();
        csRed.AddCount();
        psRed.onTrigger();
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);

        playerHasTriggerR = true;
    }

    private void adjustLeft(float input)
    {
        if (input >= 0.5)
        {
            polyL += 1;
            adjustTimer += 1;
        }
        
        if (input <= -0.5)
        {
            polyL = Mathf.Max(2, polyL - 1);
            adjustTimer += 1;
        }
    }
    
    private void adjustRight(float input)
    {
        if (input >= 0.5)
        {
            polyR += 1;
            adjustTimer += 1;
        }
        
        if (input <= -0.5)
        {
            polyR = Mathf.Max(2, polyR - 1);
            adjustTimer += 1;
        }
    }
}
