using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaedMask : MonoBehaviour
{
    public StageTrg ToStage1;    // シーン遷移判定
    private bool isFeadStage1 = false;  // シーンフラグ
    private bool isFead = false;  // フェードフラグ
    private SpriteMask mask;
    public float alphaPow;

    public bool IsFead()
    {
        return isFead;
    }

    // Start is called before the first frame update
    void Start()
    {
        mask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        isFeadStage1 = ToStage1.IsStage();
        if (!isFead)
        {
            if (isFeadStage1)
            {
                if (mask.alphaCutoff < 1)
                {
                    mask.alphaCutoff += alphaPow*Time.deltaTime; 
                }
                else if(mask.alphaCutoff >= 1)
                {
                   
                    mask.alphaCutoff = 1;
                    isFead = true;
                }
                

            }
        }



    }
}
