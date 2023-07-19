using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CaneraMove : MonoBehaviour
{
    private CinemachineBrain cinemachineBrain;  //コンポーネント取得用

    public CameraTrg cameraTrg;              // カメラトリガー
    public StageTrg stageTrg;               // ステージトリガー

    private bool isCamera = false;      // カメラフラグ
    private bool isStage = false;       // ステージ移動フラグ
    private bool isCameraMoved = false;  // カメラ移動済みフラグ

    public float moveSpeedX;    // X移動量
    public float moveLenX;      // X移動距離

    public float moveSpeedY;    // Y移動距離
    public float moveLenY;      // Y移動距離

    [SerializeField] private float waitTime;      //待機時間

    // Start is called before the first frame update
    void Start()
    {
        //cinemachineBrainのコンポーネント取得
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }

    public bool IsStageMove()
    {
        return isCameraMoved;
    }

    // Update is called once per frame
    void Update()
    {
        isCamera = cameraTrg.IsPlayer();   
        isStage = stageTrg.IsStage();

        //カメラ演出判定がtrue
        if (isCamera)
        {
            //cinemachineBrainをoff
            cinemachineBrain.enabled = false;

            //カメラの移動演出
            this.transform.DOMove(
                new Vector3(
                    moveLenX, 
                    transform.position.y, 
                    transform.position.z), 
                moveSpeedX
                );
        }


        //ステージ移動判定がtrue
        if (isStage)
        {
            StartCoroutine(CameraMoveY());
        }
    }

    private IEnumerator CameraMoveY()
    {
        yield return new WaitForSeconds(waitTime);
        //カメラの移動演出
        this.transform.DOMove(
            new Vector3(
                transform.position.x,
                -moveLenY,
                transform.position.z),
            moveSpeedY
            ).OnComplete(() =>
            {
                //移動完了時
                isCameraMoved = true;
            });
    }
}
