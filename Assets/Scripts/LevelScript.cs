using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    public float polyprim;
    public float polysec;

    public bool tutorialfinished;

    public AudioSource levelMusic;
  
    /*
    public TextAsset primtxt;
    public TextAsset sectxt;

    public List<float> primList;
    public List<float> secList;
    */
    
    // Start is called before the first frame update
    void Start()
    {
        tutorialfinished = true;
      //  primList = txtToList(primtxt);
      //  secList = txtToList(sectxt);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<float> txtToList(TextAsset txt)
    {
        List<float> timinglst = new List<float>();
        return timinglst;
    }
}
