using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public GameObject Tile;

    public static List<GameObject> TilesList { get; set; } = new List<GameObject>();

    int N = 8;
    int x = 0, y = 0, z = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = N;
        z = N;
        for(int x = 0; x < N; x++)
        {
            for (int z = 0; z < N; z++)
            {
                GameObject tile = Instantiate(Tile, new Vector3(x, y, z), Quaternion.identity);
                tile.transform.parent = transform;
                string tag = (x * 8 + z).ToString();
                Level2.AddTag(tag);
                TilesList.Add(tile);
            }
            z = N;
        }

        for (int i = 0; i < TilesList.Capacity; i++)
            TilesList.ElementAt(i).tag = i.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
