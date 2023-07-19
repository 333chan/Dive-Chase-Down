using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOff : MonoBehaviour
{
    private CinemachineBrain CameraMove;
    public CameraTrg Ctrg;
    private bool isCtrg = false;  // カメラトリガー
    private bool isSrgMove = false;  // カメラトリガー

    // Start is called before the first frame update
    void Start()
    {
        CameraMove = GetComponent<CinemachineBrain>();
    }

    public bool IsStageMove()
    {
        return isSrgMove;
    }

    // Update is called once per frame
    void Update()
    {
        isCtrg = Ctrg.IsPlayer();

        if (isCtrg)
        {
            CameraMove.enabled = false;
        }
    }
}
