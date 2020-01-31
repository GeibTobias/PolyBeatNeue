using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float position;

    public float speed;
    public float minSpeed;
    public float displaySpeed;

    public float maxSpeed;
    //public Transform startPoint;
    //public Transform endPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        minSpeed = 100;
        maxSpeed = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        speed -= 1;
        if (SongTiming.hasStarted())
        {
            speed = Mathf.Min(maxSpeed, Mathf.Max(minSpeed, speed));
            displaySpeed = Mathf.Lerp(displaySpeed, speed, displaySpeed+1 / speed);
            //position += speed;
            //transform.position = Vector3.Lerp(startPoint.position, endPoint.position, position/100);
        }
    }
}
