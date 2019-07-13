using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Level2.AddTag("Box");
        tag = "Box";
    }

    // Update is called once per frame
    void Update()
    {
        Level2.AddTag("Box");
        tag = "Box";
    }
}
