using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChage : MonoBehaviour
{
    public StageTrg StageChageTrg;    // シーン遷移判定
    private bool isStageChage = false;  // シーンフラグ

    public FaedMask Fead;    // シーン遷移判定
    private bool isFead = false;  // シーンフラグ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isStageChage = StageChageTrg.IsStage();
        isFead = Fead.IsFead();

        if(isStageChage&& isFead)
        {
            SceneManager.LoadScene("StageClear", LoadSceneMode.Single);
        }

    }
}
