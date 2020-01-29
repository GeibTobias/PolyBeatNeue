using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameObject shield;

    private ShieldScript shieldScript;

    public GameObject gameManager;

    public float probability;


    public Transform center;
    public Vector3 axis = Vector3.up;
    public float radius;
    public float radiusSpeed;
    public float rotationSpeed; 
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        shieldScript = shield.GetComponent<ShieldScript>();
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        meteorMove();
        float rand = Random.value*100;
        if (rand >= (101 - probability) - 1)
        {
             meteorRain();   
        }
        +/
    }

    void meteorRain()
    {
        if (shieldScript.shieldCapacity >= 1)
        {
            shieldScript.hitShield();
        }
        else
        {
            PlayerScript playerScript = gameManager.GetComponentInChildren<PlayerScript>();
            playerScript.hitPlayer();
        }
    }

    void meteorMove()
    {
        transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    */
    }
    
}
