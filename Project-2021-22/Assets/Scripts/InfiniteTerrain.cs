using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject theTile;
    public float creationTime;

    public Tile(GameObject t, float ct)
    {
        theTile = t;
        creationTime = ct;
    }
}

public class InfiniteTerrain : MonoBehaviour
{
    public GameObject plane;
    public GameObject player;
    
        int planesize = 10;
        int halfTilesX = 3;
        int halfTilesZ = 3;

        Vector3 startPos;

        Hashtable tiles = new Hashtable();
        
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = -halfTilesX; x < halfTilesX; x++)
        {
            for (int z = -halfTilesZ; z < halfTilesZ; z++)
            {
                Vector3 pos = new Vector3((x * planesize+startPos.x),
                0, (z * planesize+startPos.z));
                GameObject t = (GameObject) Instantiate(plane, pos,
                Quaternion.identity);

                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if(Mathf.Abs(xMove) >= planesize || Mathf.Abs(zMove) >= planesize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int playerX = (int)(Mathf.Floor(player.transform.position.x/planesize)*planesize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z/planesize)*planesize);

            for(int x = -halfTilesX; x < halfTilesX; x++)
            {
                for(int z = -halfTilesX; z < halfTilesX; z++)
                {
                    Vector3 pos = new Vector3(( x * planesize + playerX),
                    0, (z * planesize + playerZ));

                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    if(!tiles.ContainsKey(tilename))
                    {
                        GameObject t = (GameObject) Instantiate(plane, pos, Quaternion.identity);
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tilename, tile);
                    }
                    else
                    {
                        (tiles[tilename] as Tile).creationTime = updateTime;
                    }
                }
            }

        }
    }
}
