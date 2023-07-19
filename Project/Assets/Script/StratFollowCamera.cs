using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StratFollowCamera : MonoBehaviour
{
    public CameraTrg Ctrg;
    private bool isCtrg = false;  // カメラトリガー

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
            Debug.Log("追従on");
            gameObject.GetComponent<CinemachineBrain>().enabled = true;
            isCtrg = false;

        }
    }
}
