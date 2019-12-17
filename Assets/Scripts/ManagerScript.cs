using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class ManagerScript : MonoBehaviour
{

    public GameObject primaryManager;
    public BarrelScript primBScript;
    public IndicatorManager primIManager;
    
    public GameObject secondaryManager;
    public BarrelScript secBScript;
    public IndicatorManager secIManager;
    
    
    public float bpm;
    public float polyPrimary;
    public float polySecondary;

    public bool rotate;

    public List<GameObject> slitList;

    public float primTimer;
    public float secTimer;
    
    
    public AudioSource audioprime;
    public AudioSource audiosec;

    public LevelManagerScript levelmanager;

    public bool isTutorial;

    public int primCounter;
    public int secCounter;

    public int cycleCounter;

    public AudioSource currentMusic;

    public float synctimer;
    public bool started;

    public bool musicIsPlaying;
    public bool musicstarted;

    public SlitScript primeslitfront;
    public SlitScript primeslitback;
    public SlitScript secslitfront;
    public SlitScript secslitback;

    public bool hasVibrated;
    
    // Start is called before the first frame update
    void Start()
    {
        primBScript = primaryManager.GetComponent<BarrelScript>();
        
        secBScript = secondaryManager.GetComponent<BarrelScript>();
        
        //primBScript.updateManager(bpm, polyPrimary);
        //secBScript.updateManager(bpm, polySecondary);
        primBScript.UpVector3 = Vector3.forward;
        secBScript.UpVector3 = Vector3.back;
        primCounter = 1;
        secCounter = 1;
        started = false;
        musicIsPlaying = false;



    }

    // Update is called once per frame
    void Update()
    {
        
        primeslitfront.setTutorial(isTutorial);
        primeslitback.setTutorial(isTutorial);
        secslitfront.setTutorial(isTutorial);
        secslitback.setTutorial(isTutorial);
        
        
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        
        started = synctimer >= 1;
        currentMusic = levelmanager.getCurrentLevel().levelMusic;
        isTutorial = !levelmanager.getCurrentLevel().tutorialfinished;
        polyPrimary = levelmanager.getCurrentLevel().polyprim;
        polySecondary = levelmanager.getCurrentLevel().polysec;
        
        float primSpeed = calcSpeed(bpm, polyPrimary);
        float secSpeed = calcSpeed(bpm, polySecondary);

        
        if (cycleCounter == 0 & started)
        {
            if (!musicstarted)
            {
                currentMusic.Play();
                musicstarted = true;
                musicIsPlaying = true;
            }
        }
        
        if (rotate)
        {
            primTimer += Time.deltaTime;
            secTimer += Time.deltaTime;
            if (primTimer >= primSpeed)
            {
                primBScript.onTrigger();
                primIManager.onTrigger();
                audioprime.Play();
                primTimer = Mathf.Max(primTimer - primSpeed, 0);
                primCounter = primCounter + 1;
                if (primCounter > polyPrimary)
                {
                    primCounter = 1;
                    cycleCounter += 1;
                    if (cycleCounter == 8)
                    {
                        cycleCounter = 0;
                        if (isTutorial)
                        {
                            levelmanager.getCurrentLevel().tutorialfinished = true;
                        }
                        else
                        {
                            levelmanager.nextLevel();
                            currentMusic.Stop();
                            musicIsPlaying = false;
                            musicstarted = false;

                        }
                    }
                }
            }

            if (secTimer >= secSpeed)
            {
                secBScript.onTrigger();
                secIManager.onTrigger();
                audiosec.Play();
                secTimer = Mathf.Max(secTimer - secSpeed, 0);
                secCounter = ((secCounter) % Mathf.FloorToInt(polySecondary)) + 1;
            }

        }

        primBScript.rotate = rotate;
        secBScript.rotate = rotate;
        primIManager.rotate = rotate;
        secIManager.rotate = rotate;

        updateManager();
        synctimer = Mathf.Min(synctimer + Time.deltaTime, 2.0f);
    }

    
    public float calcSpeed(float bpm, float poly)
    {
        return (60.0f / bpm * 4) / poly;
    }


    void updateManager()
    {
        float pp = primBScript.poly;
        float sp = secBScript.poly;
        float pbpm = primBScript.bpm;
        float sbpm = secBScript.bpm;
        if (pp != polyPrimary | sp != polySecondary | pbpm != bpm | sbpm != bpm)
        {
            primTimer = 0;
            primBScript.updateManager(bpm, polyPrimary);
            primIManager.updateManager(bpm, polyPrimary);

            secTimer = 0;
            secBScript.updateManager(bpm, polySecondary);
            secIManager.updateManager(bpm, polySecondary);

        }

        bool hasCollision = false;
        foreach (GameObject s in slitList)
        {
            SlitScript slitScript = s.GetComponent<SlitScript>();
            if (!isTutorial & slitScript.checkCollision())
            {
                hasCollision = true;
                if (musicIsPlaying)
                {
                    Debug.Log("Pause");
                    currentMusic.Pause();
                    musicIsPlaying = false;
                }
                if (slitScript.isPrime)
                {
                    if (!hasVibrated)
                    {
                        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                        hasVibrated = true;    
                    }
                }
                else 
                {
                    if (!hasVibrated)
                    {
                        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
                        hasVibrated = true;
                    }
                }
            }
            
        }

        if (!hasCollision)
        {
            if (!musicIsPlaying)
            {
                Debug.Log("Unpause");
                currentMusic.UnPause();
                musicIsPlaying = true;
            }

            hasVibrated = false;
        }
        rotate = !hasCollision & started;
        
    }
    
}
