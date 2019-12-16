using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIndicatorScript : MonoBehaviour
{

    public GameObject gameManager;

    public ManagerScript managerScript;

    public float speed;
    

    public Transform startPoint;

    public Transform endPoint;
    
    
    public Vector3 direction;

    private float distance;

    public bool rotate;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        managerScript = gameManager.GetComponent<ManagerScript>();
        distance = Vector3.Distance(startPoint.position, endPoint.position);
        rotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            float cSpeed = distance / speed;
            transform.position +=  Time.deltaTime * direction * cSpeed;
        }    
    }

    public void onTrigger()
    {
        float distStart = Vector3.Distance(transform.position, startPoint.position);
        float distEnd = Vector3.Distance(transform.position, endPoint.position);

        if (distStart < distEnd)
        {
            transform.position = startPoint.position;
            direction = Vector3.forward;
        }
        else
        {
            transform.position = endPoint.position;
            direction = Vector3.back;
        }
        
    }
}
