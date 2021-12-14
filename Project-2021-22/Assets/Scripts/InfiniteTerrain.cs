using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class Tile created to allow each plane to be placed on a tile
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
    
        int planesize = 10;//Allows each tile to join others when created
        int halfTilesX = 3;
        int halfTilesZ = 3;

        //Keeps track of player positions
        Vector3 startPos;

        Hashtable tiles = new Hashtable();
        
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        //Sets time of when tiles are created 
        float updateTime = Time.realtimeSinceStartup;

        //Creates a 2D ground plane made up of all connected planes using the X and Z radius
        for(int x = -halfTilesX; x < halfTilesX; x++)
        {
            for (int z = -halfTilesZ; z < halfTilesZ; z++)
            {
                Vector3 pos = new Vector3((x * planesize+startPos.x),
                0, (z * planesize+startPos.z));
                GameObject t = (GameObject) Instantiate(plane, pos,
                Quaternion.identity);//plane created 

                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);//Allows tiles to be created at the same time 
                tiles.Add(tilename, tile);//Adds tiles to hashtable
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Determines how far the player has moved in these directions(X and Z)
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        //Tiles around the player are updated if player moves
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
