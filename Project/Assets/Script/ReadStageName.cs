using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadStageName : MonoBehaviour
{
    private string SaveStageName;
    public Text StageName;

    // Start is called before the first frame update
    void Start()
    {
        SaveStageName = SaveLavelName.Instance.StageName;
    }

    // Update is called once per frame
    void Update()
    {

        switch (SaveStageName)
        {
            case "Tutorial":
                StageName.text = "�`���[�g���A��\n�N���A!";
                break;
            case "Stage1":
                StageName.text = "�h�E�N�c-1\n�N���A!";
                break;
            case "Stage2":
                StageName.text = "�h�E�N�c-2\n�N���A!";
                break;
            default:
                Debug.Log("�ǂ��[");
                break;

        }
    }
}
