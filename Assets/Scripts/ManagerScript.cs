using System;
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

    public List<float> primList;
    public List<float> secList;

    public float[] primBeats;
    public float[] secBeats;


    public float primBeat;
    public float secBeat;

    public int primIterator;
    public int secIterator;


    //The number of seconds for each song beat
    //public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    //public float dspSongTime;

    public AudioSource song;

    public BeatSpawnerScript beatSpawner;

    // Start is called before the first frame update
    void Start()
    {
        //song.Play();

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

        primIterator = 0;
        secIterator = 0;

        //bpm = 120;
        //secPerBeat = 60f / bpm;

        primBeats = new float[]
        {
            2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f,
            2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f,
            2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f,
            2.5f, 1.5f, 2.5f, 1.5f, 2.5f, 1.5f,
        };
        secBeats = new float[]
        {
            1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        };
    }

    // Update is called once per frame
    void Update()
    {
        /*
        primeslitfront.setTutorial(isTutorial);
        primeslitback.setTutorial(isTutorial);
        secslitfront.setTutorial(isTutorial);
        secslitback.setTutorial(isTutorial);
*/

        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

        //started = synctimer >= 1;
        //currentMusic = levelmanager.getCurrentLevel().levelMusic;
        // isTutorial = !levelmanager.getCurrentLevel().tutorialfinished;
        // polyPrimary = levelmanager.getCurrentLevel().polyprim;
        // polySecondary = levelmanager.getCurrentLevel().polysec;
        //currentMusic = song;
        // primList = levelmanager.getCurrentLevel().primList;
        // secList = levelmanager.getCurrentLevel().secList;

        //float primSpeed = calcSpeed(bpm, polyPrimary);
        //float secSpeed = calcSpeed(bpm, polySecondary);

        //primBeat = primList[primIterator];
        //secBeat = secList[secIterator];


        if (cycleCounter == 0 & started)
        {
            if (!musicstarted)
            {
                SongTiming.dspSongTime = (float) AudioSettings.dspTime;
                song.Play();
                musicstarted = true;
                musicIsPlaying = true;
            }

            primTimer += Time.deltaTime;
            secTimer += Time.deltaTime;
            songPosition = SongTiming.getSongPosition();

            songPositionInBeats = SongTiming.getSongPositionInBeats();
//        if (primTimer >= primSpeed)
            if (songPositionInBeats > primBeat && primIterator < primBeats.Length)
            {
                primBeat += primBeats[primIterator];
                //primBScript.onTrigger();
                // primIManager.onTrigger();
                audioprime.Play();

                beatSpawner.primSpawn(primBeat);

                primBScript.updateManager(primBeats[primIterator] * SongTiming.secPerBeat);

                primIterator = Mathf.Min(primIterator + 1, primBeats.Length);

                // primTimer = Mathf.Max(primTimer - primSpeed, 0);
                // primCounter += 1;
                /*
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
    */

//            if (secTimer >= secSpeed)
            }

            if (songPositionInBeats > secBeat && secIterator < secBeats.Length)
            {
                secBeat += secBeats[secIterator];
                //secBScript.onTrigger();
                // secIManager.onTrigger();
                audiosec.Play();


                secBScript.updateManager(secBeats[secIterator] * SongTiming.secPerBeat);
                //secTimer = Mathf.Max(secTimer - secSpeed, 0);
                //secCounter = ((secCounter) % Mathf.FloorToInt(polySecondary)) + 1;
                //secCounter += 1;

                beatSpawner.secSpawn(secBeat);
                secIterator = Mathf.Min(secIterator + 1, secBeats.Length);
            }


            primBScript.rotate = rotate;
            secBScript.rotate = rotate;
            /*
            primIManager.rotate = rotate;
            secIManager.rotate = rotate;
    */
            // updateManager();
            synctimer = Mathf.Min(synctimer + Time.deltaTime, 2.0f);
            // started = primIterator >= primBeats.Length && secIterator >= secBeats.Length;
        }
    }


    public float calcSpeed(float bpm, float poly)
    {
        return (60.0f / bpm * 4) / poly;
    }


    void updateManager()
    {
        /*
        float pp = primBScript.poly;
        float sp = secBScript.poly;
        float pbpm = primBScript.bpm;
        float sbpm = secBScript.bpm;
        */
        //if (pp != polyPrimary | sp != polySecondary | pbpm != bpm | sbpm != bpm)
        // {
        //primTimer = 0;

        //primBScript.updateManager(bpm, polyPrimary);
        //primIManager.updateManager(bpm, polyPrimary);

        //secTimer = 0;

        //secBScript.updateManager(bpm, polySecondary);
        //secIManager.updateManager(bpm, polySecondary);
        // }

        /*
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
*/
        //       rotate = !hasCollision & started;
        rotate = true;
    }

    public void startSong()
    {
        started = true;
    }
}

public static class SongTiming
{
    public static float dspSongTime;
    public static float BeatsShownInAdvance = 3;

    public static int bpm = 120;

    public static float secPerBeat = 60f / bpm;


    public static float getSongPosition()
    {
        return (float) AudioSettings.dspTime - dspSongTime;
    }

    public static float getSongPositionInBeats()
    {
        return ((float) AudioSettings.dspTime - dspSongTime) / secPerBeat;
    }
}