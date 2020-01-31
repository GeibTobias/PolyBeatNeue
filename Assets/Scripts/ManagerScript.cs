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

    public bool secAd = false;
    public bool primAd = false;

    public HighscoreScript highScore;


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
            //4, 12, 20, 24,
            4, 8, 12, 16, 20, 24, 28, 32, 34, 36, 40, 44, 48, 52, 56, 60, 64, 66, 68, 71, 72, 75, 76, 79.5f, 80.5f,
            81.5f, 82.5f, 84, 87, 88, 91, 94.5f,
            95.5f, 96.5f, 97.5f, 100, 103, 104, 107, 110.5f, 111.5f, 112.5f, 113.5f, 116, 119, 120, 123, 126.5f, 127.5f,
            128.5f, 129.5f, 132, 134, 136, 138, 140, 142, 144, 146, 148, 150, 152, 154, 156, 158, 160, 162, 164, 166,
            168, 170, 172, 174, 176, 178, 180, 182, 184, 186, 188, 190, 192, 194, 196, 198, 200, 202, 203, 208, 212,
            216, 220, 224, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244.5f,
            245.5f, 246.5f, 247.5f, 248.5f, 249.5f, 250.5f, 251.5f, 252.5f, 253.5f, 254.5f, 255.5f, 256.5f, 257.5f,
            258.5f, 260,
            262, 264, 266, 268, 270, 272, 274, 276, 278, 280, 282, 284, 286, 288, 290, 292, 294, 296, 298, 300, 302,
            304, 306, 308, 310, 312, 314, 316, 318, 320, 322, 324, 326, 328, 330, 332, 334, 336, 338, 340, 342, 344,
            346, 348, 350, 352, 355, 358, 361, 364, 367, 370, 373, 376, 379, 382, 385, 388, 391, 393, 395, 397,
            399, 401, 403, 405, 407, 409, 411, 413, 415, 417, 419, 421, 423, 425, 427, 429, 431, 433, 435, 437, 439,
            441, 443, 445, 447, 449, 451, 452, 
            454, 
            456, 
            458, 
            460, 
            462, 
            464, 
            466, 
            468, 
            470, 
            472, 
            474, 
            476, 
            478, 
            480, 
            482, 
            484, 
            486, 
            488, 
            490, 
            492, 
            494, 
            496, 
            498, 
            500, 
            502, 
            504, 
            506, 
            508, 
            510, 
            512, 
            514, 
            516, 
            518, 
            520, 
            522, 
            524, 
            526, 
            528, 
            530, 
            532, 
            534, 
            536, 
            538, 
            540, 
            542, 
            544, 
            546, 
            548, 
            550, 
            552, 
            554, 
            556, 
            558, 
            560, 
            562, 
            564, 
            566, 
            568, 
            570, 
            572, 
            574, 
            576, 
            578, 
            580, 
            582, 
            584, 
            586, 
            588, 
            590, 
            592, 
            594, 
            596, 
            597.5f, 
            599.0f, 
            600.5f, 
            602.0f, 
            603.5f, 
            605.0f, 
            606.5f, 
            608.0f, 
            609.5f, 
            611.0f, 
            612.5f, 
            614.0f, 
            615.5f, 
            617.0f, 
            618.5f, 
            620.0f, 
            621.5f, 
            623.0f, 
            624.5f, 
            626.0f, 
            627.5f, 
            629.0f, 
            630.5f, 
            632.0f, 
            633.5f, 
            635.0f, 
            636.5f, 
            638.0f, 
            639.5f, 
            641.0f, 
            642.5f, 
            644.0f, 
            645.5f, 
            647.0f, 
            648.5f, 
            650.0f, 
            651.5f, 
            653.0f, 
            654.5f, 
            656.0f, 
            657.5f, 
            659.0f, 
            660.5f, 
            662.0f, 
            663.5f, 
            665.0f, 
            666.5f, 
            668.0f, 
            669.5f, 
            671.0f, 
            672.5f, 
            674.0f, 
            675.5f, 
            677.0f, 
            678.5f, 
            680.0f, 
            681.5f, 
            683.0f, 
            684.5f, 
            686.0f, 
            687.5f, 
            689.0f, 
            690.5f, 
            
            
            //79.5f, 80.5f, 81.5f, 82.5f, 87.5f, 90.5f, // 1, 2, 2,
            //3, 0.5f, 1, 1, 1, 5, 3, 0.5f, 1, 1, 1, 5, 3, 1, 2, 2, 3, 0.5f, 1, 1, 1, 5,
        };
        secBeats = new float[]
        {
            //  4, 12, 20, 24,

            4, 8, 12, 16, 20, 24, 28, 32, 34, 37, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59, 61, 63, 65, 67, 69, 91, 97,
            99, 101,
            103, 105, 107, 109, 111, 113, 115, 117, 119, 121, 123, 125, 127, 129, 131, 132, 136, 140, 144, 148, 152,
            156, 160, 164, 168, 172, 176, 180, 184, 188, 192, 196, 200, 204, 208, 210, 212, 214, 216, 218, 220, 222,
            224, 226, 228, 228.5f, 229.5f, 230.5f, 231.5f, 232.5f, 233.5f, 234.5f, 235.5f, 236.5f, 237.5f, 238.5f,
            239.5f, 240.5f, 241.5f, 242.5f, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256,
            257, 258, 259, 260, 263, 266, 269, 272, 275, 278, 281, 284, 287, 290, 293, 296, 299, 302, 305, 308, 311,
            314, 317, 320, 323, 326, 329, 332, 335, 338, 341, 344, 347, 350, 352, 354, 356, 358, 360, 362, 364, 366,
            368, 370, 372, 374, 376, 378, 380, 382, 384, 386, 388, 390.5f, 392, 394.5f, 396, 398.5f, 390, 392.5f, 394,
            396.5f, 398, 400.5f, 402, 404.5f, 406, 408.5f, 410, 412.5f, 414, 416.5f, 418, 420.5f, 422, 424.5f, 426,
            428.5f, 430, 432.5f, 434, 436.5f, 438, 440.5f, 442, 444.5f, 446, 448.5f, 450, 452, 452.75f, 
            453.5f, 
            455.0f, 
            456.5f, 
            458.0f, 
            459.5f, 
            461.0f, 
            462.5f, 
            464.0f, 
            465.5f, 
            467.0f, 
            468.5f, 
            470.0f, 
            471.5f, 
            473.0f, 
            474.5f, 
            476.0f, 
            477.5f, 
            479.0f, 
            480.5f, 
            482.0f, 
            483.5f, 
            485.0f, 
            486.5f, 
            488.0f, 
            489.5f, 
            491.0f, 
            492.5f, 
            494.0f, 
            495.5f, 
            497.0f, 
            498.5f, 
            500.0f, 
            501.5f, 
            503.0f, 
            504.5f, 
            506.0f, 
            507.5f, 
            509.0f, 
            510.5f, 
            512.0f, 
            513.5f, 
            515.0f, 
            516.5f, 
            518.0f, 
            519.5f, 
            521.0f, 
            522.5f, 
            524.0f, 
            525.5f, 
            527.0f, 
            528.5f, 
            530.0f, 
            531.5f, 
            533.0f, 
            534.5f, 
            536.0f, 
            537.5f, 
            539.0f, 
            540.5f, 
            542.0f, 
            543.5f, 
            545.0f, 
            546.5f, 
            548.0f, 
            549.5f, 
            551.0f, 
            552.5f, 
            554.0f, 
            555.5f, 
            557.0f, 
            558.5f, 
            560.0f, 
            561.5f, 
            563.0f, 
            564.5f, 
            566.0f, 
            567.5f, 
            569.0f, 
            570.5f, 
            572.0f, 
            573.5f, 
            575.0f, 
            576.5f, 
            578.0f, 
            579.5f, 
            581.0f, 
            582.5f, 
            584.0f, 
            585.5f, 
            587.0f, 
            588.5f, 
            590.0f, 
            591.5f, 
            593.0f, 
            594.5f, 
            596.0f,
            598, 
            600, 
            602, 
            604, 
            606, 
            608, 
            610, 
            612, 
            614, 
            616, 
            618, 
            620, 
            622, 
            624, 
            626, 
            628, 
            630, 
            632, 
            634, 
            636, 
            638, 
            640, 
            642, 
            644, 
            646, 
            648, 
            650, 
            652, 
            654, 
            656, 
            658, 
            660, 
            662, 
            664, 
            666, 
            668, 
            670, 
            672, 
            674, 
            676, 
            678, 
            680, 
            682, 
            684, 
            686, 
            688, 
            690




            //97, // 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            //2, 2, 2, 2, 2,
        };

        //SongTiming.started = true;
    }

    // Update is called once per frame
    void Update()
    {
        //SongTiming.started = started;
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


        if (cycleCounter == 0 & SongTiming.hasStarted())
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
                primBScript.updateManager((primBeats[primIterator] - primBeat) * SongTiming.secPerBeat);
                primBeat = primBeats[primIterator];
                //primBScript.onTrigger();
                // primIManager.onTrigger();
                audioprime.Play();

                if (!primAd)
                {
                    beatSpawner.primSpawn(primBeat);
                    beatSpawner.primSpawn(primBeats[primIterator + 1]);
                    beatSpawner.primSpawn(primBeats[primIterator + 2]);
                    primAd = true;
                }
                else if (!(primIterator + 2 >= primBeats.Length))
                {
                    beatSpawner.primSpawn(primBeats[primIterator + 2]);
                }


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
                secBScript.updateManager((secBeats[secIterator] - secBeat) * SongTiming.secPerBeat);
                secBeat = secBeats[secIterator];
                //secBScript.onTrigger();
                // secIManager.onTrigger();
                audiosec.Play();


                //secTimer = Mathf.Max(secTimer - secSpeed, 0);
                //secCounter = ((secCounter) % Mathf.FloorToInt(polySecondary)) + 1;
                //secCounter += 1;

                if (!secAd)
                {
                    beatSpawner.secSpawn(secBeat);
                    beatSpawner.secSpawn(secBeats[secIterator + 1]);
                    beatSpawner.secSpawn(secBeats[secIterator + 2]);
                    secAd = true;
                }
                else if (!(secIterator + 2 >= secBeats.Length))
                {
                    beatSpawner.secSpawn(secBeats[secIterator + 2]);
                }

                secIterator = Mathf.Min(secIterator + 1, secBeats.Length);
            }

            primBScript.rotate = rotate;
            secBScript.rotate = rotate;
            /*
            primIManager.rotate = rotate;
            secIManager.rotate = rotate;
    */
            updateManager();
            synctimer = Mathf.Min(synctimer + Time.deltaTime, 2.0f);
            // started = primIterator >= primBeats.Length && secIterator >= secBeats.Length;
            if (primIterator >= primBeats.Length && secIterator >= secBeats.Length)
            {
                SongTiming.started = false;
                highScore.onFinished();

                primBScript.rotate = false;
                secBScript.rotate = false;
            }
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


        bool hasCollision = false;
        foreach (GameObject s in slitList)
        {
            SlitScript slitScript = s.GetComponent<SlitScript>();
//            if (!isTutorial & slitScript.checkCollision())
            if (slitScript.checkCollision())
            {
                hasCollision = true;

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

/*
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
    public static float BeatsShownInAdvance = 3f;

    public static int bpm = 160;

    public static float secPerBeat = 60f / bpm;

    public static bool started;

    public static float getSongPosition()
    {
        return (float) AudioSettings.dspTime - dspSongTime;
    }

    public static float getSongPositionInBeats()
    {
        return ((float) AudioSettings.dspTime - dspSongTime) / secPerBeat;
    }

    public static bool hasStarted()
    {
        return started;
    }
}