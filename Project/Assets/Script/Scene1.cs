using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public StageTrg ToStage1;    // シーン遷移判定
    private bool isToStage1 = false;  // シーンフラグ

    public FaedMask Fead;    // シーン遷移判定
    private bool isFead = false;  // シーンフラグ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isToStage1 = ToStage1.IsStage();
        isFead = Fead.IsFead();

        if (isToStage1 && isFead)
        {
            isToStage1 = false;
            SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
        }

    }
}
