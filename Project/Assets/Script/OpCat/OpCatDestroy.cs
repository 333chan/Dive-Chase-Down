using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpCatDestroy : MonoBehaviour
{


    public CatDoorTrg CatDoortrg;   // 猫用ドアのトリガー
    private bool isCatDoortrg = false;  // 猫用ドア
    private bool isCatDestry = false;   // 猫削除済み

    public OpSkip Skip;
    private bool isSkip;

    public bool IsCatDestry()
    {
        return isCatDestry;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isCatDoortrg = CatDoortrg.IsCatDoor();
        isSkip = Skip.IsSkip();

        if (isCatDoortrg)
        {
            Destroy(this.gameObject);
            isCatDestry = true;
        }

        //if(Input.GetKey(KeyCode.P))
        //{
        //    Destroy(this.gameObject);
        //    isCatDestry = true;
        //}

        if (isSkip)
        {
            Destroy(this.gameObject);
        }
    }
}
