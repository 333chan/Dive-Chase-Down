using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletReradMOve : MonoBehaviour
{
    public Player2 Player;    // プレイヤースクリプト
    private bool isPlayerReload = false;  // Reload判定
    RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
            
        if(!isPlayerReload)
        {
            isPlayerReload = Player.IsReload();
            if (isPlayerReload)
            {

                //rectTrans.DOMove(new Vector2(rectTrans.position.x, rectTrans.position.y + 100.0f), 0.05f)
                //    .SetLoops(2, LoopType.Yoyo);
                isPlayerReload = false;
            }
        }



    }
}
