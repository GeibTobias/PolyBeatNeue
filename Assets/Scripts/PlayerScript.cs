﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float position;

    public float speed;
    public float minSpeed;
    public Transform startPoint;
    public Transform endPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongTiming.hasStarted())
        {
            speed = Mathf.Max(minSpeed, speed);
            position += speed;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, position/100);
        }
    }
}
