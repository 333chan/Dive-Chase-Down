using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public Bgmtrg bgm;
    private bool IsBgmStart = false;
    private bool IsPlay = false;
    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsBgmStart = bgm.IsBgm();
        if(IsBgmStart)
        {
            if(!IsPlay)
            {
                IsPlay = true;
                Audio.Play();
            }
        }
    }
}
