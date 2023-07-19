using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrg : MonoBehaviour
{
    private string PlayerTag = "Player";    // 地面タグ
    private bool isPCollsion = false;    // プレイヤーが入った判定
    private bool isWCollsion = false;    // 壁の当たり判定
    private bool isBlackBar = false;    //  黒帯の出現判定

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsPlayer()
    {
        return isPCollsion;
    }

    public bool IsWall()
    {
        return isWCollsion;
    }

    public bool IsBlackBar()
    {
        return isBlackBar;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
           // Debug.Log("判定に入った");
            isPCollsion = true;
            isBlackBar = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isWCollsion = true;
           // Debug.Log("判定から出たよ");
        }
    }

}
