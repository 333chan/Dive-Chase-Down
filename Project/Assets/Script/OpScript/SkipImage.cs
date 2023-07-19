using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipImage : MonoBehaviour
{
    public Connection Connect;
    private bool isConnect;

    public GameObject Key;
    public GameObject pad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isConnect = Connect.IsConnection();


        if (isConnect)
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
