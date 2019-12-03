using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingScript : MonoBehaviour
{

    public LayerMask layer;

    public GameObject beatunit;
    
    private Vector3 previousPos;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit,0.2f,layer))
        {
            float percentage = hit.transform.gameObject.GetComponent<BallScript>().percentage;

            
            HighscoreScript.AddScore(percentage);

            //Debug.Log(beatunit.transform.forward);
        }

        previousPos = transform.position;
    }
}
