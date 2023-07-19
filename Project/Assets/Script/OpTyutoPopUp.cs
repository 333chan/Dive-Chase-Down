using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpTyutoPopUp : MonoBehaviour
{
    public OpPlayer Opplayer;
    private bool isGetUp;

    private SpriteRenderer sp;  // スプライトレンダラーの格納用
    public float alpha;     // 透明度
    public float alphaFeadTime;  // 加算時間
    public float DiffY;     // Y差分
    public float MoveTime;  // 移動にかかる時間
    public float WaitTime;  // 待機時間

    private Vector2 Pos; // 現在地格納用

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();    // スプライトレンダラーの取得
                                                // alpha = 0;  // 初期透明度
        Pos = transform.position;   // 現在の位置
    }

    // Update is called once per frame
    void Update()
    {
        isGetUp = Opplayer.IsGetUp();

        if(isGetUp)
        {
            StartCoroutine(TyutoPop());
        }
    }

    public IEnumerator TyutoPop()
    {

        yield return new WaitForSeconds(WaitTime);
        // 移動
        transform.DOMoveY(Pos.y + DiffY, MoveTime);


        // 透明度の加算
        if (alpha >= 1)
        {
            alpha = 1f;
        }
        else
        {
            alpha += alphaFeadTime * Time.deltaTime;
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, alpha);
        }
    }
}
