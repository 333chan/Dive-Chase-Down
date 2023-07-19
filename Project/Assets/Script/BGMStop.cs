using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStop : MonoBehaviour
{
    public CircleArea BgmStop;
    private bool isBgm;

    public AudioSource Audio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isBgm = BgmStop.IsBgm();
        if(isBgm)
        {
            Audio.mute = true;
            isBgm = false;
        }
    }
}
