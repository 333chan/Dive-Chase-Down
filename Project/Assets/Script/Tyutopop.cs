using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tyutopop : MonoBehaviour
{
    public TyutoTrg tyutoTrg;       // チュートリアル表示
    private bool isTyutoPop = false;    // チュートリアル表示

    private SpriteRenderer sp;  // スプライトレンダラーの格納用
    public float alpha;     // 透明度
    public float alphaFeadTime;  // 加算時間
    public float DiffY;     // Y差分
    public float MoveTime;  // 移動にかかる時間
    public float WaitTime;  // 待機時間

    private bool isMoveUI = false;

    private Vector2 Pos; // 現在地格納用

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();    // スプライトレンダラーの取得
        alpha = 0;  // 初期透明度
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, alpha);
        Pos = transform.position;   // 現在の位置
    }

    // Update is called once per frame
    void Update()
    {
        isTyutoPop = tyutoTrg.IsTyutoPop();

        if (isTyutoPop)
        {
            StartCoroutine(TyutoPopUI());
        }
    }

    public IEnumerator TyutoPopUI()
    {
        yield return new WaitForSeconds(WaitTime);
        // 移動
        transform.DOMoveY(Pos.y + DiffY, MoveTime);
        if (!isMoveUI)
        {
            isMoveUI = true;
        }

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
