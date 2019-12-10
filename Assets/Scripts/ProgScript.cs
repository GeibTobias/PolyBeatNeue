using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgScript : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;

    public GameObject indObj;

    private List<GameObject> indicatorGameObjects = new List<GameObject>();
    
    public float poly;

    public Vector3 dirVector3;

    public Material StandardMaterial;

    public Material IlluminationMaterial;

    private int counter;

    private GameObject ciGO;
    
    
    // Start is called before the first frame update
    void Start()
    {
        dirVector3 = endPoint.transform.position - startPoint.transform.position;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateGameState(float gsPoly)
    {
        poly = gsPoly;
        counter = 0;
        
        for (int i = 0; i < indicatorGameObjects.Count; i++)
        {
            Destroy(indicatorGameObjects.ElementAt(i));
        }
        indicatorGameObjects = new List<GameObject>();
        for (float i = poly; i > 0; i--)
        {
            Debug.Log(dirVector3/ i );
            indicatorGameObjects.Add(Instantiate(indObj, endPoint.position - dirVector3 * i / poly, new Quaternion(0, 0, 0, 0)));
        }
    }

    public void onTrigger()
    {
        GameObject prevciGO = indicatorGameObjects[counter];;
        prevciGO.GetComponent<Renderer>().material = StandardMaterial;
        
        counter = (counter + 1) % Mathf.RoundToInt(poly);
        ciGO = indicatorGameObjects[counter];
        ciGO.GetComponent<Renderer>().material = IlluminationMaterial;
    }


}
