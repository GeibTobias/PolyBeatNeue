using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float shieldCapacity;

    public float maxShield;

    public float minShield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addShield()
    {
        shieldCapacity = Mathf.Min(shieldCapacity + (maxShield - minShield)/10, maxShield);
    }

    public void hitShield()
    {
        shieldCapacity = Mathf.Max(shieldCapacity - 10,minShield); 
    }
}
