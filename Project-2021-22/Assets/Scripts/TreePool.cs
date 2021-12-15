using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePool : MonoBehaviour
{
    //Sets number of trees to be created and are then placed into an array
    static int numTrees = 1000;
    public GameObject treePrefab;
    static GameObject[] trees;

    // Start is called before the first frame update
    void Start()
    {
        //Array is set to size of the number of trees
        trees = new GameObject[numTrees];
        for (int i = 0; i < numTrees; i++)
        {
            //Trees are created
            trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            trees[i].SetActive(false);
        }
    }

    // Loop that looks for any avalaible trees and adds them to plane
    //If none available then null is returned
    static public GameObject getTree()
    {
        for (int i = 0; i < numTrees; i++)
        {
            if(!trees[i].activeSelf)
            {
                return trees[i];
            }
        }
        return null;
    }
    
}
