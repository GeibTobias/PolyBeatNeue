using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContCubeScript : MonoBehaviour
{
    
    //public Transform point_min;

    public float min = 0;
    public float max = 1;
    
    //public Transform point_max;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        if (pos.z < min)
        {
            transform.localPosition = new Vector3(pos.x,pos.y,min);
        }
        else if (pos.z > max)
        {
            transform.localPosition = new Vector3(pos.x,pos.y,max);    
        }
        
    }
}
