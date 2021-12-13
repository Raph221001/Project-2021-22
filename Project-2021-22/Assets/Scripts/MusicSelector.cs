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
        TrackSelector = Random.Range(0, 3);

        if(TrackSelector == 0)
        {
            Track1.Play();
            TrackHistory = 1;
        }

        else
        {
            Track2.Play();
            TrackHistory = 2;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Track1.isPlaying == false && Track2.isPlaying)
        {
            TrackSelector = Random.Range(0, 3);

            if(TrackSelector == 0 && TrackHistory != 1)
            {
                Track1.Play();
            }

            else
            {
                Track2.Play();
            }
        }
    }
}
