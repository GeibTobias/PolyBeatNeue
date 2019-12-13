using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlitScript : MonoBehaviour
{
    public GameObject spawnPoint;

    public List<GameObject> bounds;

    public GameObject gameManager;

    public ManagerScript managerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        managerScript = gameManager.GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool noCollision = true;
        foreach(GameObject go in bounds)
        {
       //     if (go)
       //     {
       //         
       //     }
        }
        //managerScript.rotate = noCollision
    }
}
