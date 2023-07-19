using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOff : MonoBehaviour
{
    private CinemachineBrain CameraMove;
    public CameraTrg Ctrg;
    private bool isCtrg = false;  // �J�����g���K�[
    private bool isSrgMove = false;  // �J�����g���K�[

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
