using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadStage : MonoBehaviour
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
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
                }
                break;
            case "Stage1":
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
                }
                break;
            case "Stage2":
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
                }
                break;
            default:
                Debug.Log("Ç«Ç±Å[");
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("TitleStage 1", LoadSceneMode.Single);
                }
                break;

        }

    }
}
