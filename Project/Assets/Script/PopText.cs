using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopText : MonoBehaviour
{
    public Connection Connected;    // �ڑ�
    private bool isConnect = false;  // �ڑ��t���O

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
