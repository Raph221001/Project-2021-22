using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTerrain : MonoBehaviour
{
    //Added to set a good height for the terrain
    int heightscale = 5;
    float detailScale = 5.0f;
    List<GameObject> myTrees = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int v = 0; v < vertices.Length; v++)
        {
            //height of vertex is set using perlin noise function
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detailScale, 
            (vertices[v].z + this.transform.position.z)/detailScale)*heightscale;

            if(vertices[v].y > 3.6 && Mathf.PerlinNoise((vertices[v].x+5)/10,(vertices[v].z+5)/10)*10 > 4.6)
            {
                GameObject newTree = TreePool.getTree();
                if (newTree != null)
                {
                    Vector3 treePos = new Vector3(vertices[v].x + this.transform.position.x,
                    vertices[v].y, vertices[v].z + this.transform.position.z);
                    newTree.transform.position = treePos;
                    newTree.SetActive(true);
                    myTrees.Add(newTree);
                }
            }
        }

    //Set vertices that were in previous array and put it back onto mesh
    mesh.vertices = vertices;
    mesh.RecalculateBounds();
    mesh.RecalculateNormals();
    this.gameObject.AddComponent<MeshCollider>();//Added to enable movement on the surface 

    }

    void OnDestroy()
    {
        for(int i = 0; i < myTrees.Count; i++)
        {
            if(myTrees[i] != null)
                myTrees[i].SetActive(false);
        }
        myTrees.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
