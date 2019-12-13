using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{

    public GameObject Manager;
    public GameObject Barrel;
    public float poly;
    public ManagerScript managerScript;

    public bool rotate;

    public float timer;

    public float speed;

    public AudioSource audio;

    public float bpm;

    public float distance;

    public Vector3 forward;

    public Vector3 UpVector3;
    
    // Start is called before the first frame update
    void Start()
    {
        rotate = false;
        Manager = GameObject.Find("GameManager");
        managerScript = Manager.GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //worldY = Barrel.transform.forward.y; 
        forward = Barrel.transform.forward;
        distance = Vector3.Distance(Vector3.left, forward);
        if (rotate)
        {
            speed = managerScript.calcSpeed(bpm, poly);
        
            Barrel.transform.Rotate (Barrel.transform.up, Time.deltaTime * (180  / speed), Space.World);
            timer += Time.deltaTime;
            if (timer > speed)
            {
                onTrigger();
            }
        }
    }

    void onTrigger()
    {
        timer = Mathf.Max(0,timer -speed);


        if (distance < 1)
        {
            
            Barrel.transform.up = UpVector3;
            Barrel.transform.Rotate (Barrel.transform.up, 270, Space.World);
        }
        else
        {
            Barrel.transform.up = UpVector3;
            Barrel.transform.Rotate (Barrel.transform.up, 90, Space.World);
        }
        audio.Play();
    }


    public void updateManager(float bpm, float poly)
    {
        if (this.poly != poly | this.bpm != bpm)
        {
            this.poly = poly;
            this.bpm = bpm;
        }
        onTrigger();
    }
    
}
