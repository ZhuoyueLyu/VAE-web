using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGame : MonoBehaviour
{
    int gameIndex = 0;
    int numGames = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))
        { 
            transform.GetChild(gameIndex % numGames).gameObject.SetActive(false);
            gameIndex += 1;
            transform.GetChild(gameIndex % numGames).gameObject.SetActive(true);
        }
        
    }
}
