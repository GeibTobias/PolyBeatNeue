using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] cubes;

    public Transform[] points;

    public float beat;

    public float poly1;
    
    public float poly2;

    public float timer1;
    public float timer2;

    private float poly1beat;
    private float poly2beat;

    private float baseBeat;
    // Start is called before the first frame update
    void Start()
    {

        beat = 60 / beat;
        baseBeat = beat * 4;
        poly1beat = baseBeat / poly1;
        poly2beat = baseBeat / poly2;

        
        //Instantiate(cubes[0], points[0]);
        //Instantiate(cubes[1], points[1]);

        //cubes[0].polyBeat = poly1beat;
        //cubes[1].polyBeat = poly2beat;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer1 > poly1beat)
        {
            //GameObject cube = Instantiate(cubes[0], points[0]);
            //cube.transform.localPosition = Vector3.zero;

            timer1 -= poly1beat;
        }
        
        if (timer2 > poly2beat)
        {
            //GameObject cube = Instantiate(cubes[1], points[1]);
            //cube.transform.localPosition = Vector3.zero;

            timer2 -= poly2beat;
        }

        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
    }
}
