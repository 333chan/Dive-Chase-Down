using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StratFollowCamera : MonoBehaviour
{
    public CameraTrg Ctrg;
    private bool isCtrg = false;  // �J�����g���K�[

    private CinemachineBrain CameraMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isCtrg = Ctrg.IsPlayer();

        if (isCtrg)
        {
            Debug.Log("�Ǐ]on");
            gameObject.GetComponent<CinemachineBrain>().enabled = true;
            isCtrg = false;

        }
    }
}
