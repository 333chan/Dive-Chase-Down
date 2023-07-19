using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageOn : MonoBehaviour
{
    public OpMask OpMask;
    private bool isMask;

    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = this.gameObject.GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isMask = OpMask.IsMaskEnd();
        if(isMask)
        {
            sp.enabled = true;
        }
        

    }
}
