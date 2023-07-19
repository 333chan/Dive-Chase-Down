using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpCatDestroy : MonoBehaviour
{


    public CatDoorTrg CatDoortrg;   // �L�p�h�A�̃g���K�[
    private bool isCatDoortrg = false;  // �L�p�h�A
    private bool isCatDestry = false;   // �L�폜�ς�

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
