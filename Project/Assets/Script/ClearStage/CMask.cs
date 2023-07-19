using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMask : MonoBehaviour
{
    public StageTrg MaskTrg;
    private bool isMaskTrg;

    public OpMask MaskEnd;
    private bool isMaskEnd;

    private SpriteMask mask;
    public float alphaPow;

    // Start is called before the first frame update
    void Start()
    {
        mask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        isMaskTrg = MaskTrg.IsStage();
        isMaskEnd = MaskEnd.IsMaskEnd();

        if(isMaskEnd)
        {
            this.mask.enabled = true;
        }

        if (isMaskTrg)
        {
            
            if (mask.alphaCutoff <= 1)
            {
                mask.alphaCutoff += alphaPow * Time.deltaTime;
            }
            if (mask.alphaCutoff == 1)
            {
            }
        }
    }
}
