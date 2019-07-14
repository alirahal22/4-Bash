using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    int winner = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver())
            Debug.Log("Player " + winner + " Wins");
        
    }

    bool GameOver()
    {
        int numOfSurvivors = 0;
        for (int i = 0; i < Level1.survivors.Length; i++)
            if (Level1.survivors[i] == 1)
                numOfSurvivors++;
        if (numOfSurvivors == 1)
        {
            for (int i = 0; i < Level1.survivors.Length; i++)
                if (Level1.survivors[i] == 1)
                    winner = i + 1;
            return true;
        }
        return false;
    }
}
