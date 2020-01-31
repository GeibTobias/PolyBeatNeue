using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlitScript : MonoBehaviour
{
    public GameObject spawnPoint;

    public LayerMask layer;

    public GameObject gameManager;

    public ManagerScript managerScript;

    public bool isPrime;
    
    
    public Material standardMaterial;

    public Material tutorialMaterial;

    public bool tutorial;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        managerScript = gameManager.GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkCollision()
    {
        RaycastHit hit;
        Vector3 offset = new Vector3(0, 0, transform.localScale.z);
        Vector3 yAdjust = new Vector3(0,transform.localScale.y /2,0);
        if (Physics.Raycast(transform.position + yAdjust - offset, Vector3.forward, out hit, transform.localScale.z*1.3f
                , layer))
        {
            hit.transform.gameObject.GetComponent<BeatUnitScript>().onPlayerHit();
//            Debug.Log(hit.transform.parent.gameObject);
            return true;
        }
        else
        {
            
            return false;
        }
    }
    
    public void setTutorial(bool tutorial)
    {
        if (this.tutorial != tutorial)
        {
            this.tutorial = tutorial;
            if (tutorial)
            {
                GetComponent<Renderer>().material = tutorialMaterial;
            }
            else
            {
                GetComponent<Renderer>().material = standardMaterial;
            }

        }
    }
    
}
