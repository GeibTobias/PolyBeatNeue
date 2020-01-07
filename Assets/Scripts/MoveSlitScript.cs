using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlitScript : MonoBehaviour
{


    public Transform minpoint;
    public Transform maxpoint;

    public GameObject hand;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dist;

        float hpos = hand.transform.position.z;

        float minz = minpoint.position.z;
        float maxz= maxpoint.position.z;
        
        if (hpos < minz)
        {
            dist = 0;
        }
        else if(hpos > maxz)
        {
            dist = 1;
        }
        else
        {
            dist = Mathf.Abs(hpos - minz) / Mathf.Abs(minz - maxz);
        }
        
        //float adjustZpos = calcPos(contCube.transform.localPosition);
        transform.localPosition= new Vector3(transform.localPosition.x,transform.localPosition.y,dist);
    }

    
 
}
