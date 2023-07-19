using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    [SerializeField] private float AlphaPow;    //Alphaの加算量

    private float waitTime_ = 2.0f;  //処理待機時間

    private SpriteMask mask_;        //コンポーネント取得用

    private bool isLogo_ = false;    //logoの表示フラグ
    private bool isMask_ = false;    //Mask処理フラグ
    private bool isScene_ = false;   //Scene遷移フラグ


    // Start is called before the first frame update
    void Start()
    {
        //SpriteMaskコンポーネントを取得
        mask_ = GetComponent<SpriteMask>();  
    }

    // Update is called once per frame
    void Update()
    {
        //スプラッシュスクリーンの表示が終わっていれば
        if (SplashScreen.isFinished) 
        {
            if (!isLogo_)
            {
                isLogo_ = true;

                //コルーチン処理開始
                StartCoroutine(HometoScene());
            }
        }

        if(isMask_)
        {
            if (mask_.alphaCutoff <= 1)
            {
                //alphaCutoffを1になるまで加算
                mask_.alphaCutoff += AlphaPow * Time.deltaTime;
            }
        }

        if(mask_.alphaCutoff == 1)
        {
            isMask_ = false;

            //オブジェクトの表示をオフに
            gameObject.SetActive(false);

            isScene_ = true;
        }

        if(isScene_)
        {
            isScene_ = false;

            // HomeSceneに遷移
            SceneManager.LoadScene("Home", LoadSceneMode.Single);
        }

    }

    public IEnumerator HometoScene()
    {
        //2秒待機
        yield return new WaitForSeconds(waitTime_);
        isMask_ = true;
    }
}
