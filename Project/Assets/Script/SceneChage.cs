using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChage : MonoBehaviour
{
    public StageTrg StageChageTrg;    // �V�[���J�ڔ���
    private bool isStageChage = false;  // �V�[���t���O

    public FaedMask Fead;    // �V�[���J�ڔ���
    private bool isFead = false;  // �V�[���t���O

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
