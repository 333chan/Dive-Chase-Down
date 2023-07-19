using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToTutorial : MonoBehaviour
{
    public StageTrg ToStage1;    // �V�[���J�ڔ���
    private bool isToStage1 = false;  // �V�[���t���O

    public CaneraMove cameramove;
    private bool isCameramove = false;  // �J�����̈ړ������t���O

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
