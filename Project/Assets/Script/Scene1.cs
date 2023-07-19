using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public StageTrg ToStage1;    // �V�[���J�ڔ���
    private bool isToStage1 = false;  // �V�[���t���O

    public FaedMask Fead;    // �V�[���J�ڔ���
    private bool isFead = false;  // �V�[���t���O

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
