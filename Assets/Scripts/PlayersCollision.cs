using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Collider c1 in GetComponentsInChildren<Collider>())
            foreach (Collider c2 in GetComponentsInChildren<Collider>())
                if (!c1.Equals(c2))
                    Physics.IgnoreCollision(c1, c2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
