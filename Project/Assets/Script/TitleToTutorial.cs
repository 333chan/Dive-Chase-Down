using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToTutorial : MonoBehaviour
{
    public StageTrg ToStage1;    // シーン遷移判定
    private bool isToStage1 = false;  // シーンフラグ

    public CaneraMove cameramove;
    private bool isCameramove = false;  // カメラの移動完了フラグ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isToStage1 = ToStage1.IsStage();
        isCameramove = cameramove.IsStageMove();

        if (isToStage1 && isCameramove)
        {
            isToStage1 = false;
            SceneManager.LoadScene("tutorial", LoadSceneMode.Single);
        }

    }

}
