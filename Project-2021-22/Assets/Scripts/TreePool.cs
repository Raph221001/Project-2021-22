using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePool : MonoBehaviour
{
    //Sets number of trees to be created and are then placed into an array
    static int no_of_trees = 1000;
    public GameObject treePrefab;
    static GameObject[] Trees;

    // Start is called before the first frame update
    void Start()
    {
        //Array is set to size of the number of trees
        Trees = new GameObject[no_of_trees];
        for (int i = 0; i < no_of_trees; i++)
        {
            //Trees are created
            Trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            Trees[i].SetActive(false);
        }
    }

    // Loop that looks for any avalaible trees and adds them to plane
    //If none available then null is returned
    static public GameObject getTree()
    {
        for (int i = 0; i < no_of_trees; i++)
        {
            if(!Trees[i].activeSelf)
            {
                return Trees[i];
            }
        }
        return null;
    }
    
}
