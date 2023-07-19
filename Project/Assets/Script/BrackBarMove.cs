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

    private string BrackBarObj;     // 黒帯の名前取得用

    public CameraTrg Ctrg;
    private bool isCtrg = false;  // 黒帯出現トリガー
    private bool isActiv = true;  // 起動トリガー

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
                Debug.Log("知らない子ですね");
                break;

        }




    }
}
