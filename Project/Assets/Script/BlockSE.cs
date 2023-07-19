using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSE : MonoBehaviour
{

    public AudioSource Audio;
    public AudioClip Block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SE()
    {
        Audio.PlayOneShot(Block);
    }
}
