using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSe : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip CatDoorClose;
    public AudioClip DoorOpen;

    public OpCatDestroy opCatDestoytrg;   // ”Líœ‚ÌƒgƒŠƒK[
    private bool isCatDestoy = false;  // ”Líœ

    private bool isAudioPlay = false;   // ‰¹ºÄ¶


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isCatDestoy = opCatDestoytrg.IsCatDestry();
        if(isCatDestoy)
        {
            if(!isAudioPlay)
            {
                isAudioPlay = true;
                Audio.PlayOneShot(CatDoorClose);
            }

        }

    }
}
