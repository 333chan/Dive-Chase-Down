using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopText : MonoBehaviour
{
    public Connection Connected;    // 接続
    private bool isConnect = false;  // 接続フラグ

    public GameObject Key;
    public GameObject pad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isConnect = Connected.IsConnection();

        if(isConnect)
        {
            Key.SetActive(false);
            pad.SetActive(true);
        }
        else
        {
            Key.SetActive(true);
            pad.SetActive(false);
        }
    }
}
