using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class ManagerScript : MonoBehaviour
{

    public GameObject primaryManager;
    public BarrelScript primBScript;
    
    public GameObject secondaryManager;
    public BarrelScript secBScript;
    
    
    public float bpm;
    public float polyPrimary;
    public float polySecondary;

    public bool rotate;

    public List<GameObject> slitList;
    
    // Start is called before the first frame update
    void Start()
    {
        primBScript = primaryManager.GetComponent<BarrelScript>();
        secBScript = secondaryManager.GetComponent<BarrelScript>();
        //primBScript.updateManager(bpm, polyPrimary);
        //secBScript.updateManager(bpm, polySecondary);
        primBScript.UpVector3 = Vector3.forward;
        secBScript.UpVector3 = Vector3.back;



    }

    // Update is called once per frame
    void Update()
    {
        
        primBScript.rotate = rotate;
        secBScript.rotate = rotate;
        updateManager();
    }

    
    public float calcSpeed(float bpm, float poly)
    {
        return (60.0f / bpm * 4) / poly;
    }


    void updateManager()
    {
        float pp = primBScript.poly;
        float sp = secBScript.poly;
        float pbpm = primBScript.bpm;
        float sbpm = secBScript.bpm;
        if (pp != polyPrimary | sp != polySecondary | pbpm != bpm | sbpm != bpm)
        {
            primBScript.updateManager(bpm, polyPrimary);
            secBScript.updateManager(bpm, polySecondary);
        }

        bool hasCollision = false;
        foreach (GameObject s in slitList)
        {
            SlitScript slitScript = s.GetComponent<SlitScript>();
            if (slitScript.checkCollision())
            {
                hasCollision = true;
            }
        }
        rotate = !hasCollision;
    }
    
}
