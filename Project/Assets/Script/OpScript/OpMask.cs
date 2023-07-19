using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpMask : MonoBehaviour
{
    private SpriteMask mask;
    public float alphaPow;

    private bool isMaskEnd = false;



    public bool IsMaskEnd()
    {
        return isMaskEnd;
    }

    // Start is called before the first frame update
    void Start()
    {
        mask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mask.alphaCutoff <= 1)
        {
            mask.alphaCutoff += alphaPow * Time.deltaTime;
        }

        if (mask.alphaCutoff == 1)
        {
            isMaskEnd = true;
            Destroy(this);
            gameObject.SetActive(false);

        }
    }
}
