using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BrackBarMove : MonoBehaviour
{
    public float MovePow;
    private float TarGetPos;
    public float MoveTime;

    private string BrackBarObj;     // ���т̖��O�擾�p

    public CameraTrg Ctrg;
    private bool isCtrg = false;  // ���яo���g���K�[
    private bool isActiv = true;  // �N���g���K�[

    RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        BrackBarObj = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        isCtrg = Ctrg.IsBlackBar();

        switch (BrackBarObj)
        {
            case "LeftBlack":
                if (isCtrg)
                {
                    if (isActiv)
                    {
                        TarGetPos = MovePow;
                        rectTrans.DOAnchorPos(new Vector2(TarGetPos, 0), MoveTime);
                        isActiv = false;
                    }

                }
                break;
            case "RightBlack":
                if (isCtrg)
                {
                    if (isActiv)
                    {
                        TarGetPos =-MovePow;
                        rectTrans.DOAnchorPos(new Vector2(TarGetPos, 0), MoveTime);
                        isActiv = false;
                    }

                }
                break;
            default:
                Debug.Log("�m��Ȃ��q�ł���");
                break;

        }




    }
}
