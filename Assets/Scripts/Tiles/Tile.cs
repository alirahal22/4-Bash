using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int remainingHits = 7;
    Rigidbody rb;
    Material InsideMaterial;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            if (r.tag.Equals("Inside"))
                InsideMaterial = r.material;

    }



    // Update is called once per frame
    private void OnCollisionExit(Collision collision)
    {
        if(InsideMaterial == null)
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                if (r.tag.Equals("Inside"))
                    InsideMaterial = r.material;
        remainingHits--;
        if (remainingHits == 5)
            InsideMaterial.SetColor("_Color", Color.yellow);
        if (remainingHits == 3)
            InsideMaterial.SetColor("_Color", Color.red);
        if (remainingHits <= 1)
            rb.isKinematic = false;
        
    }
}
