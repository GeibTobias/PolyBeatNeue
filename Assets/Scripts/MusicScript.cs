using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class MusicScript : MonoBehaviour
{
    public AudioSource music;

    public float bpm;
    public float rhythm1;
    public float rhythm2;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startMusic()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
