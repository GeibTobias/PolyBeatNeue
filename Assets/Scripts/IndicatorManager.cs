using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{

    public GameObject gameManager;
    public ManagerScript managerScript;

    public float poly;
    public float bpm;
    public float speed;

    public FloorIndicatorScript fiScript;

    public bool rotate;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        managerScript = gameManager.GetComponent<ManagerScript>();
        rotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        fiScript.rotate = rotate;
    }

    public void updateManager(float bpm, float poly)
    {
        this.poly = poly;
        this.bpm = bpm;
        speed = calcSpeed(bpm, poly);

        fiScript.speed = speed;
        fiScript.onTrigger();
    }

    public void onTrigger()
    {
        fiScript.onTrigger();
    }
    
    private float calcSpeed(float bpm, float poly)
    {
        return (60.0f / bpm * 4) / poly;
    }
}
