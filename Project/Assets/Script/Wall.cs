using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public CameraTrg Ctrg;
    private bool isCtrg = false;  // カメラトリガー
    private BoxCollider2D BoxCol = null;    // ボックスコライダー

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
