# Project Title

Name: Raphael Ofeimu

Student Number: C18359123

Class Group: DT 282/4

# Description of Project

The goal of this project was to create a procedurally generated terrain with procedural trees. The player would have the ability to walk and jump around the the terrain while listening to the calm music that would be playing as the project is running. The leaves on the trees also move as if there is wind blowing them from side to side. The idea behind all of this was to fully enhance the user experience while they are walking throgh the procedural world. There is also a day and night cycle feature which makes seem like the player has been exploring this world for days.

# Instructions for use

You should first press the play button in Unity to start the project. Once the project has started running the player drop on the terrain where they have a great experience ahead of them. The WASD keys can be used to control the player as well as the arrow keys. Your mouse or touchpad can be used to look around and move in whatever direction you want. If you want to jump the spacebar button may be pressed to achieve this.

# How it Works

## Procedural Terrain

An infinite terrain is generated here using the perlin noise function. As the player walks closer to the edge of the map more terrain is generated and this cycle will continue forever. In the code snippet below it basically shows how the tiles of the plane are generated as the player moves around. The player's position is kept track of and as they move aound the the plane behind them is destoryed as more generates ahead.

```C#
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
```

## Procedural Trees

Trees were created by using the Unity GameObject. They all have a capsule collidor which prevents the player from walking through them and allows them to collide with the trees. The trees also have a wind zone which can give the player the impression that there is actual wind blowing and therfore causing the movement of the leaves on the trees.

```C#
//Array is set to size of the number of trees
        Trees = new GameObject[no_of_trees];
        for (int i = 0; i < no_of_trees; i++)
        {
            //Trees are created
            Trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            Trees[i].SetActive(false);
        }
```
You can up above how the array is set to however many trees there are and is then created in this loop.

(Tree Image) (https://drive.google.com/file/d/1CJP85Z8-5sgiDyxp01ReK2cwwWzw4xvk/view?usp=sharing)

## Movement

Movement was done using CharacterController and with the variables speed, gravity and jumpheight. I created a mouselook script as well to enable the player to look in the direction they would like to move.

```C#
void Update()
    {
        //Contains input for mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Clamp prevents player from over rotating and looking beyond the set 90 degrees
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Enables player to move relative to the mouse movement
        playerBody.Rotate(Vector3.up * mouseX);
    }
```
This is the code that allows the player to do such a thing.

To enable jumping the spacebar key was set as the jump button. Gravity was added by multiplying it with time and adding it to the velocity which was then added to the player.

## Day and Night Cycle

This was added by using two scripts where one was used to allow the instance of the class to be created as a file in Unity and the other was where the actual code was done. As the timeofDay increased (set in a range of 0 - 35) different gradients and colours would be seen in the sky as it became late or bright. 

```C#
if(Application.isPlaying)
        {
            //Time will be updated and then lighting
            //TimeOfDay is equal to 35 as range is set from 0 - 35 
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 35;
            UpdateLighting(TimeOfDay / 35f);
        }
```
In that little snippet of code you can see how the TimeOfDay is updated.

## Music Selector

The music selector script enables music to be played while the project is running. When the project starts a random song from the list is selected and played. The player can edit and add more songs to the selection and have more variety of songs to listen to while exploring this project. Here is a code snippet to see a bit what this section is about:

```C#
//If no music is playing a random track will play
        if(Track1.isPlaying == false && Track2.isPlaying == false)
        {
            TrackSelector = Random.Range(0, 2);

            //Stops Trackselctor from playing the same song back to back 
            if(TrackSelector == 0 && TrackHistory != 1)
            {
                Track1.Play();
                TrackHistory = 1;
            }

            else if(TrackSelector == 1 && TrackHistory != 2)
            {
                Track2.Play();
                TrackHistory = 2;
            }
```
# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset | Source |
|-----------|-----------|
| AddTerrain.cs | From [https://www.youtube.com/watch?v=dycHQFEz8VI&t=1319s&ab_channel=Holistic3d]|
| InfiniteTerrain.cs | Modified from [https://www.youtube.com/watch?v=dycHQFEz8VI&t=1319s&ab_channel=Holistic3d] |
| LightingManager.cs | From [https://www.youtube.com/watch?v=m9hj9PdO328&t=301s&ab_channel=ProbablySpoonie] |
| LightingPreset.cs | From [https://www.youtube.com/watch?v=m9hj9PdO328&t=301s&ab_channel=ProbablySpoonie] |
| MouseLook.cs | Self-Made |
| Movement.cs | Self-Made |
| MusicSelector.cs | Self-Made |
| TreePool.cs | Self-Made |
| OptimizedTreePrefab.cs | Self-Made |

# References

Tutorial - https://www.youtube.com/watch?v=dycHQFEz8VI&t=1319s&ab_channel=Holistic3d

Lighting - https://www.youtube.com/watch?v=m9hj9PdO328&t=301s&ab_channel=ProbablySpoonie

What is Procedural Generation in Unity - https://www.red-gate.com/simple-talk/development/dotnet-development/procedural-generation-unity-c/


# Proposal

The goal of this assignment is to create an impressive system in Unity that uses procedural generation, 3D models and paints a picture in code. I would like to create an infinite terrain with procedural trees for this terrain. I would also like to have other procedural objects on the terrain that can really enhance the user experience while going through the terrain. There would most likely be clouds that would be created for the sky as well (Unfortunately couldn't get that implemented).

# What am I most proud of in the assignment

There are alot of things that I am proud of in this assignment. I am proud of the fact that I was able to create a fully working day and night loop as it really enhances the experience for users. It may not have been alot of code but there was still a decent bit of research involved to understand aspects such as [CreateAssetMenu] and [ExecuteAlways]. I am also proud of creating infinte trees to match the infinite terrain as that was not easy. Once again there was alot of research involved but I got there in the end. In general I am proud of myself for getting through this assignment and having a project that I am more than satisfied to submit.

# Youtube Video

[!][YouTube Vid](https://youtu.be/t0a66ACeTVc)
