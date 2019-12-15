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
        Vector3 offset = new Vector3(0, 0, transform.localScale.z / 2);
        Vector3 yAdjust = new Vector3(0,transform.localScale.y /2,0);
        if (Physics.Raycast(transform.position + yAdjust - offset, Vector3.forward, out hit, transform.localScale.z
                , layer) |
            Physics.Raycast(transform.position +yAdjust + offset, Vector3.back, out hit, transform.localScale.z,
                layer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
