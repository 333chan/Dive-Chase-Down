using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoPop : MonoBehaviour
{
    private bool isPop = true;  // ê∂ê¨ÉgÉäÉKÅ[

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPop)
        {
            transform.DOMove(new Vector3(transform.position.x,
               transform.position.y - 1.5f,
               transform.position.z)
                , 0.4f).SetLoops(-1, LoopType.Yoyo);
            isPop = false;
        }
    }
}
