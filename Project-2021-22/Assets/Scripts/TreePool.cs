using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePool : MonoBehaviour
{
    int numTrees = 100;
    public GameObject treePrefab;
    GameObject[] trees;
    
    // Start is called before the first frame update
    void Start()
    {
        trees = new GameObject[numTrees];
        for (int i = 0; i < numTrees; i++)
        {
            trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            trees[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
