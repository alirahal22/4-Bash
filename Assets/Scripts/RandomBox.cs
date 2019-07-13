using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BoxPrefab;

    void Start()
    {
        InvokeRepeating("SpawnBox", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBox()
    {
        System.Random rnd = new System.Random();
        int x = rnd.Next(0, 8);
        int z = rnd.Next(0, 8);


        GameObject tile = Instantiate(BoxPrefab,
            new Vector3(x, 0.2f, z),
            Quaternion.identity);
        tile.transform.parent = transform;
    }
}
