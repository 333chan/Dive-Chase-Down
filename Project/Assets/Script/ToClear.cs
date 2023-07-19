using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToClear : MonoBehaviour
{
    public StageToClear ToStrg;    // シーン遷移判定
    private bool isToScene = false;  // シーンフラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isToScene = ToStrg.IsToClear();

        if (isToScene)
        {
            isToScene = false;
            SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
        }
    }
}
