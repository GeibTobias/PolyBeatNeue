using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TrackScript : MonoBehaviour
{
    public float trackLength;

    public float enemy_pos;


    public Transform startPoint;

    public Transform endPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        trackLength = 100;
        enemy_pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongTiming.hasStarted())
        {
            enemy_pos += Time.deltaTime;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, enemy_pos/100);

        }

    }
}
