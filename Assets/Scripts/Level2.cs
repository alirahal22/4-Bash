using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public static int[][] fieldMatrix { get; set; } = new int[8][] {
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
        new int[8] {-1, -1, -1, -1, -1, -1, -1, -1, },
    };

    static int[] playersScores = new int[4] { 0, 0, 0, 0 };



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void collectPoints(int player)
    {
        //Print Matrix
        //string matrix = "";
        //for (int i = 0; i < fieldMatrix.Length; i++)
        //{
        //    for (int j = 0; j < fieldMatrix[i].Length; j++)
        //        matrix += fieldMatrix[i][j] + " ";
        //    matrix += "\n";
        //}
        //Debug.Log(matrix);

        for (int i = 0; i < fieldMatrix.Length; i++)
            for(int j = 0; j < fieldMatrix[i].Length; j++)
                if(fieldMatrix[i][j] == player)
                {
                    fieldMatrix[i][j] = -1;
                    playersScores[player]++;
                    GameObject tile = FieldGenerator.TilesList.ElementAt(i * 8 + j);
                    foreach (Renderer r in tile.GetComponentsInChildren<Renderer>())
                        if (r.tag.Equals("Inside"))
                        {
                            r.material.SetColor("_Color", Color.white);
                        }
                }
        Debug.Log("Player " + (player+1) + " Score: " + playersScores[player]);
    }

    public static void AddTag(string tag)
    {
        UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
        if ((asset != null) && (asset.Length > 0))
        {
            SerializedObject so = new SerializedObject(asset[0]);
            SerializedProperty tags = so.FindProperty("tags");

            for (int i = 0; i < tags.arraySize; ++i)
            {
                if (tags.GetArrayElementAtIndex(i).stringValue == tag)
                {
                    return;     // Tag already present, nothing to do.
                }
            }

            tags.InsertArrayElementAtIndex(0);
            tags.GetArrayElementAtIndex(0).stringValue = tag;
            so.ApplyModifiedProperties();
            so.Update();
        }
    }

}
