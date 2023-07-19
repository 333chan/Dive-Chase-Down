using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLavelName : MonoBehaviour
{
    public readonly static SaveLavelName Instance = new SaveLavelName();
    public string StageName = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        Instance.StageName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
