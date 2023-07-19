using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClaerScene : MonoBehaviour
{
    public StageTrg ChangeStageTrg;    // シーン遷移判定
    private bool isChangeStage = false;  // シーンフラグ

    private string SaveStageName;

    // Start is called before the first frame update
    void Start()
    {
        SaveStageName = SaveLavelName.Instance.StageName;
    }

    // Update is called once per frame
    void Update()
    {
        isChangeStage = ChangeStageTrg.IsStage();

        if (isChangeStage)
        {
            isChangeStage = false;
            switch (SaveStageName)
            {
                case "Tutorial":
                    SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
                    break;
                case "Stage1":
                    SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
                    break;
                case "Stage2":
                    SceneManager.LoadScene("ClearText", LoadSceneMode.Single);
                    break;
                default:
                    Debug.Log("どこー");
                    break;

            }
        }


    }
}
