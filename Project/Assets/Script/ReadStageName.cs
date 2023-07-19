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
                StageName.text = "チュートリアル\nクリア!";
                break;
            case "Stage1":
                StageName.text = "ドウクツ-1\nクリア!";
                break;
            case "Stage2":
                StageName.text = "ドウクツ-2\nクリア!";
                break;
            default:
                Debug.Log("どこー");
                break;

        }
    }
}
