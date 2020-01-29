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
    // public float poly;
    public ManagerScript managerScript;

    public bool rotate;

    public float speed;

    //public float bpm;

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
    // change to Lerp
    void Update()
    {
        //worldY = Barrel.transform.forward.y; 
        forward = Barrel.transform.forward;
        distance = Vector3.Distance(Vector3.left, forward);
        if (rotate)
        {
            //speed = managerScript.calcSpeed(bpm, poly);
        
            Barrel.transform.Rotate (Barrel.transform.up, Time.deltaTime * (180  / speed), Space.World);
        }
    }

    public void onTrigger()
    {
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
    }


    public void updateManager(float speed)
    {
        this.speed = speed;
        onTrigger();
    }
    
}
