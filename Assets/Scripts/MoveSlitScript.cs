using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlitScript : MonoBehaviour
{

    public GameObject hand;

    public float minDistance;
    public float maxDistance;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float adjustZpos = Mathf.Min(Mathf.Max((hand.transform.localPosition.z + hand.transform.localPosition.x * 15),minDistance), maxDistance);
        transform.position= new Vector3(transform.position.x,transform.position.y,adjustZpos);
    }
}
