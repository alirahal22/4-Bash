using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTile : MonoBehaviour
{
    Material InsideMaterial;
    int tileTag = -1;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            if (r.tag.Equals("Inside"))
                InsideMaterial = r.material;
        

    }



    // Update is called once per frame
    private void OnCollisionExit(Collision collision)
    {
        if (tileTag == -1)
            tileTag = Convert.ToInt32(tag);

        int playerNumber = Convert.ToInt32(collision.transform.tag);
        int i = tileTag / 8;
        int j = tileTag % 8;
        Level2.fieldMatrix[i][j] = playerNumber;

        if (InsideMaterial == null)
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                if (r.tag.Equals("Inside"))
                    InsideMaterial = r.material;
        foreach (Renderer r in collision.gameObject.GetComponentsInChildren<Renderer>())
            if (r.tag.Equals("RobotMaterial"))
            {
                InsideMaterial.SetColor("_Color", r.material.color);
            }
    }
}
