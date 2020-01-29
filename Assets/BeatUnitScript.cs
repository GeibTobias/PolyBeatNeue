using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatUnitScript : MonoBehaviour
{
    public float beatOfThisNote;
    
    public Transform spawnpoint;

    public Transform endpoint;

    public ManagerScript manager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float songPosInBeats = SongTiming.getSongPositionInBeats();
        Vector3 despawnPoint = endpoint.position + (endpoint.position - spawnpoint.position);
        transform.position = Vector3.Lerp(
                spawnpoint.position,
                despawnPoint,
                (SongTiming.BeatsShownInAdvance - (beatOfThisNote - songPosInBeats)) /SongTiming.BeatsShownInAdvance/2
            );
        if (transform.position == despawnPoint)
        {
            onDespawn();
        } 
    }

    public void onPlayerHit()
    {
        
    }

    public void onDespawn()
    {
        Destroy(gameObject);
    }
}
