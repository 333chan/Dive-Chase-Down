using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Connection : MonoBehaviour
{
    private bool isConnect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public bool IsConnection()
    {
        return isConnect;
    }


    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current == null)
        {
            isConnect = false;
        }
        else  // �Q�[���p�b�h���ڑ�����Ă���ꍇ
        {
            isConnect = true;
        }
    }
}
