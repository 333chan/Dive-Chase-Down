using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLogo : MonoBehaviour
{
    public Titletrg Ttrg;            //受け渡し用
    private bool isTtrg = false;     //タイトル出現トリガー
    private bool isParticle = true;  //パーティクルアクティブトリガー

    private string TitleObj;         //タイトル演出のオブジェクト名取得用

    public float alphaPow;           //Alphaの加算量

    //パーティクルの削除にかける時間
    private float ParticledDethTime = 2.5f;

    //ParticleSystemコンポーネント取得用
    public ParticleSystem particle;

    //SpriteMaskコンポーネント取得用
    private SpriteMask mask;

    //効果音
    public AudioSource Audio;
    public AudioClip TitileLogoSE;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト名取得
        TitleObj = this.gameObject.name;
        //SpriteMaskコンポーネントを取得
        mask = GetComponent<SpriteMask>();      
    }

    // Update is called once per frame
    void Update()
    {
        //タイトルの演出判定を入れる
        isTtrg = Ttrg.IsTite();

        //オブジェクト名で判断
        switch (TitleObj)
        {
            case "Titlelogo":
                if (isTtrg)
                {
                    if (isParticle)
                    {
                        //パーティクルシステムのインスタンス生成
                        ParticleSystem newParticle = Instantiate(particle);
                        // 発生場所をアタッチしているGameObjectの位置に
                        newParticle.transform.position = this.transform.position;
                        //パーティクルの発生
                        newParticle.Play();
                        //効果音の調整
                        Audio.pitch = 1;
                        Audio.volume = 1;
                        Audio.PlayOneShot(TitileLogoSE);

                        //パーティクルの削除
                        Destroy(newParticle.gameObject, ParticledDethTime);  

                        //パーティクルフラグをfalseに
                        isParticle = false;
                    }
                }
                break;
            case "TitleMask":
                if (isTtrg)
                { 
                    if (mask.alphaCutoff <= 1)
                    {
                        //alphaCutoffが1になるまで加算
                        mask.alphaCutoff += alphaPow*Time.deltaTime;
                    }
                }
                break;
            default:
                Debug.Log("オブジェクト名不一致");
                break;
        }



    }
}