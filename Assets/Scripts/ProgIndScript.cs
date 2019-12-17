using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgIndScript : MonoBehaviour
{


    public GameObject progPrefab;
    
    public List<GameObject> progList;

    public IndicatorManager indicatorManager;

    public Transform startPoint;

    public Transform endPoint;

    public float distance;

    public float poly;

    public int counter;
    
    
    public Material StandardMaterial;

    public Material IlluminationMaterial;

    public float margin;
    
    // Start is called before the first frame update

    void Start()
    {
        distance = Vector3.Distance(startPoint.position, endPoint.position);
        margin = 0.1f;
    }


    // Update is called once per frame

    void Update()
    {
        if (progList.Count > 1)
        {
            progList[progList.Count - 1].GetComponent<Renderer>().material =
                progList[0].GetComponent<Renderer>().material;   
        }
    }

    public void onUpdate()
    {
        poly = indicatorManager.poly;
        counter = 0;
        
        foreach (var p in progList)
        {
            Destroy(p);
        }
        progList = new List<GameObject>();
        for (int i = 0; i < poly+1; i++)
        {
            Vector3 pPos = startPoint.position + new Vector3((distance / (poly + 1)) * i + distance / (poly + 1)/2, 0, 0);
            GameObject progUnit = Instantiate(progPrefab, pPos, new Quaternion(0, 0, 0, 0));
            progUnit.transform.localScale = new Vector3(distance/(poly+1) - margin,0.7f,0.1f);
            progList.Add(progUnit);
        }  

        

        onTrigger();
        counter = 0;
    }

    public void onTrigger()
    {
     
        GameObject currentProg = progList[counter];
        
        currentProg.GetComponent<Renderer>().material = StandardMaterial;
        
        counter = (counter + 1) % Mathf.FloorToInt(poly);

        currentProg = progList[counter];
        currentProg.GetComponent<Renderer>().material = IlluminationMaterial;
        
    }
    
}
