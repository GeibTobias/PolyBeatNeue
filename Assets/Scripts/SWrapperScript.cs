using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SWrapperScript : MonoBehaviour
{
    public GameObject percent;

    public ShieldScript shield;

    private List<GameObject> pList;
    // Start is called before the first frame update
    void Start()
    {
        pList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shield.shieldCapacity > pList.Count)
        {
            for (int i = pList.Count; i < shield.shieldCapacity; i++)
            {

                GameObject p =Instantiate(percent,
                    new Vector3(transform.position.x * (i + 1), transform.position.y, transform.position.z),new Quaternion(0,0,0,0));
                pList.Append(p);
            }
        } else if (shield.shieldCapacity < pList.Count)
        {
            for (int i = Mathf.FloorToInt(shield.shieldCapacity); i < pList.Count; i++)
            {
                Destroy(pList[i]);
            }
        }
        
    }
}
