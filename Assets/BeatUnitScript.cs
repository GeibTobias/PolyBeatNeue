using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatUnitScript : MonoBehaviour
{
    public float beatOfThisNote;
    
    public Transform spawnpoint;

    public Transform endpoint;

    public ManagerScript manager;

    public Material hitMaterial;

    public PlayerScript player;

    //public AudioSource desSound;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float songPosInBeats = SongTiming.getSongPositionInBeats();
        Vector3 despawnPoint = new Vector3(endpoint.position.x,(endpoint.position.y  - spawnpoint.position.y),endpoint.position.z); ;
        transform.position = Vector3.Lerp(
                spawnpoint.position,
                despawnPoint,
                ((SongTiming.BeatsShownInAdvance - (beatOfThisNote - songPosInBeats)) /SongTiming.BeatsShownInAdvance)/2
            );
        if (transform.position == despawnPoint)
        {
            onDespawn();
        } 
    }

    public void onPlayerHit()
    {
        //desSound.Play();
        Debug.Log("Destroy" + SongTiming.getSongPositionInBeats());
        player.speed += 100;
        /*
        while (desSound.isPlaying)
        {
            yield return null;
        }
        */
//        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void onDespawn()
    {
        player.speed -= 75;
        Destroy(gameObject);
    }
}
