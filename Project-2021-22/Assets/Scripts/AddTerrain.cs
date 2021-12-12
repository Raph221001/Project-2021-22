using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTerrain : MonoBehaviour
{
    //Added to set a good height for the terrain
    int heightscale = 5;
    float detailScale = 5.0f;
    public GameObject Firtree;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int v = 0; v < vertices.Length; v++)
        {
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detailScale, 
            (vertices[v].z + this.transform.position.z)/detailScale)*heightscale;

        }

    mesh.vertices = vertices;
    mesh.RecalculateBounds();
    mesh.RecalculateNormals();
    this.gameObject.AddComponent<MeshCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
