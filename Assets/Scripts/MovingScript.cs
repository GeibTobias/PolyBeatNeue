using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{

    public float beat;
    public float polyBeat;

    public float distance;

    
    // Start is called before the first frame update
    void Start()
    {
        beat = 60.0f / beat;
        float baseBeat = beat * 4.0f;
        polyBeat = baseBeat / polyBeat;
        Debug.Log("Started");
        GameObject player1 = GameObject.Find("PlayerWall");
        GameObject player2 = GameObject.Find("CatchWall");
        
        distance = Vector3.Distance(player1.transform.position, player2.transform.position) -0.8f;
        Debug.Log(distance);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(distance);
        Debug.Log(polyBeat);
        transform.position += Time.deltaTime * transform.forward * distance / polyBeat;
        //Debug.Log(transform.forward);
    }
}
