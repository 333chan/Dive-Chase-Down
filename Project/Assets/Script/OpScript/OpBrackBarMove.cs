using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OpBrackBarMove : MonoBehaviour
{
    public float MovePow;
    private float TarGetPos;
    public float MoveTime;

    public OpPlayer GetUp;
    private bool isGetUp;

    public OpSkip Skip;
    private bool isSkip;

    private string BrackBarObj;     // 黒帯の名前取得用

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
        isGetUp = GetUp.IsGetUp();
        isSkip = Skip.IsSkip();

        switch (BrackBarObj)
        {
            case "UpBlack":
                if (isGetUp||isSkip)
                {
                    if (isActiv)
                    {
                        TarGetPos = MovePow;
                        isActiv = false;
                        rectTrans.DOAnchorPos(new Vector2(0, TarGetPos), MoveTime).OnComplete(()=>
                        {
                            Destroy(gameObject);
                        });
                        
                        
                    }

                }
                break;
            case "UnderBlack":
                if (isGetUp || isSkip)
                {
                    if (isActiv)
                    {
                        isActiv = false;
                        TarGetPos =-MovePow;
                        rectTrans.DOAnchorPos(new Vector2(0, TarGetPos), MoveTime).OnComplete(() =>
                        {
                            Destroy(gameObject);
                        });
                    }

                }
                break;
            default:
                Debug.Log("知らない子ですね");
                break;

        }




    }
}
