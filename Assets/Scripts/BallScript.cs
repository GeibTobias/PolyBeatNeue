using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Transform[] points;

    public float distance;

    public float percentage;

    public float bpm;

    public float polydivision;

    public float speed;

    public float quaver;

    public float margin;

    public float timer;

    public float polybeat;

    public CountScript counter;

    public AudioSource sound;

    public MusicScript music;

    public HighscoreScript score;
    // Start is called before the first frame update
    void Start()
    {
        Transform point1 = points[0];
        Transform point2 = points[1];
        distance = Vector3.Distance(point1.transform.position, point2.transform.position);
        float b = 60.0f / bpm;
        float normalized_b = b * quaver;
        polybeat = normalized_b / polydivision;
        speed = distance / polybeat ;
        //music.startMusic();
    }

    // Update is called once per frame
    void Update()
    {
        float max_cd = 0;
        Vector3 current_pos = transform.position;

        Transform minPoint = points[0];

        for (int i = 0; i < points.Length; i++)
        {
            
            float current_d = Vector3.Distance(current_pos, points[i].transform.localPosition);

            if (current_d <= Vector3.Distance(current_pos, minPoint.transform.position))
            {
                minPoint = points[i];
            }
            
            if (current_d > max_cd)
            {
                max_cd = current_d;
            }
        }
        if (timer > polybeat)
        {
            transform.position = minPoint.transform.localPosition;
            //Debug.Log(maxPoint.transform.localPosition);
            //Debug.Log(transform.position);
            timer -= polybeat;
            //Debug.Log(transform.rotation.y);
            if (transform.rotation.y > 0)
            {
                transform.rotation = new Quaternion(0,0,0,0);
            }
            else
            {
                transform.rotation = new Quaternion(0,180,0,0);
            }
            sound.Play();

            counter.AddCount();

            if (counter.getCount() == 1)
            {
                music.startMusic();
            }
            
            score.SetHittable();
            
            //Debug.Log(transform.position);
        }
        
        
        percentage = max_cd /distance;
        
        //Debug.Log(transform.forward);
        
        transform.position += Time.deltaTime * transform.forward * speed;
        
        
        //Debug.Log(transform.position);
        
        timer += Time.deltaTime;
    }
}
