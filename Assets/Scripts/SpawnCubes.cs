using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{

    public GameObject indicatorCube;
    public GameObject spawnTop;
    public GameObject spawnBottom;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnCubes(3);
        transform.Rotate(new Vector3(90,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.forward, Time.deltaTime*100, Space.World);
    }

    public void spawnCubes(int interval)
    {


        for(int i=0; i < interval; i++)
        {
            bool isEven = i % 2 == 1;
            GameObject cubeNew;
            if (isEven)
            {
                cubeNew = Instantiate(this.indicatorCube, spawnTop.transform.position, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                cubeNew = Instantiate(this.indicatorCube, spawnBottom.transform.position, new Quaternion(0, 0, 0, 0));

            }

            cubeNew.transform.parent = this.transform;
            cubeNew.transform.RotateAround(this.transform.localPosition,new Vector3(0,1,0),(360 / interval) * i);
            
        }
        
    }
    
    
}
