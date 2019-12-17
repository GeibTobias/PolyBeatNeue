using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public List<LevelScript> levelList;

    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LevelScript getCurrentLevel()
    {
        return levelList[currentLevel];
    }
    
    public void nextLevel()
    {
        currentLevel = Mathf.Min(currentLevel + 1, levelList.Count-1);
    }
}
