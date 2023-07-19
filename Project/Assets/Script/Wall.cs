using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public CameraTrg Ctrg;
    private bool isCtrg = false;  // �J�����g���K�[
    private BoxCollider2D BoxCol = null;    // �{�b�N�X�R���C�_�[

    // Start is called before the first frame update
    void Start()
    {
        BoxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isCtrg = Ctrg.IsWall();

        if(isCtrg == true)
        {
            BoxCol.enabled = true;
        }
    }
}
