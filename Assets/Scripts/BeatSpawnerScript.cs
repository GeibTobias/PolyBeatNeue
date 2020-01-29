using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawnerScript : MonoBehaviour
{

    public Transform primSpawnFront;
    public Transform primSpawnBack;
    public Transform secSpawnFront;
    public Transform secSpawnBack;
    
    public Transform primEndFront;
    public Transform primEndBack;
    public Transform secEndFront;
    public Transform secEndBack;

    public GameObject primBeatUnit;
    public GameObject secBeatUnit;

    private int primCounter;

    private int secCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void primSpawn(float beat)
    {
        primCounter += 1;
        Transform spawnPoint = primSpawnFront;
        Transform endPoint = primEndFront;
        if (primCounter % 2 == 0)
        {
            spawnPoint = primSpawnBack;
            endPoint = primEndBack;
        }

        
        GameObject beatunit = Instantiate(primBeatUnit, spawnPoint);
        BeatUnitScript bu = beatunit.GetComponent<BeatUnitScript>();
        bu.spawnpoint = spawnPoint;
        bu.endpoint = endPoint;
        bu.beatOfThisNote = beat;
    }
    
    
    public void secSpawn(float beat)
    {
        secCounter += 1;
        Transform spawnPoint = secSpawnFront;
        Transform endPoint = secEndFront;
        if (secCounter % 2 == 0)
        {
            spawnPoint = secSpawnBack;
            endPoint = secEndBack;
        }

        
        GameObject beatunit = Instantiate(secBeatUnit, spawnPoint);
        BeatUnitScript bu = beatunit.GetComponent<BeatUnitScript>();
        bu.spawnpoint = spawnPoint;
        bu.endpoint = endPoint;
        bu.beatOfThisNote = beat;
    }
}
