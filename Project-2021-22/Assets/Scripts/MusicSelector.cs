using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    public AudioSource Track1;

    public AudioSource Track2;

    public int TrackSelector;

    public int TrackHistory;

    // Start is called before the first frame update
    void Start()
    {
        // Sets range of tracks that can be selected to 2 as there are 2 tracks
        TrackSelector = Random.Range(0, 2);

        // Track 1 will play if first track is chosen
        if(TrackSelector == 0)
        {
            Track1.Play();
            TrackHistory = 1;
        }
        
        // Otherwise the second track will play
        else if(TrackSelector == 1)
        {
            Track2.Play();
            TrackHistory = 2;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
}
