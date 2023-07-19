using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightCameratrg : MonoBehaviour
{

    private string playerTag = "Player";
    private bool rihgttrg;    // 当たり判定
    public bool IsCollsin()
    {
        return rihgttrg;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            rihgttrg = true;
             Debug.Log("カメラ移動右範囲に入った");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            rihgttrg = false;
             Debug.Log("カメラ移動右範囲からでた");
        }

    }
}
