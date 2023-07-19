using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpCollsion : MonoBehaviour
{
    private string TileTag = "Ground";    // 地面タグ
    private bool isWallCollsion = false;    // 当たり判定

    private string BlockTag = "Block";    // 地面タグ

    private bool isWallEnter, isWallStay, isWallExit;
    public bool IsWallJump()
    {
        if (isWallEnter || isWallStay)
        {
            isWallCollsion = true;
        }
        else if (isWallExit)
        {
            isWallCollsion = false;
        }
        isWallEnter = false;
        isWallStay = false;
        isWallExit = false;

        return isWallCollsion;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isWallEnter = true;
  //          Debug.Log("壁ジャンの判定に入った");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isWallStay = true;
    //        Debug.Log("壁ジャンの判定内にあるよ");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isWallExit = true;
      //      Debug.Log("壁ジャンの判定から出たよ");
        }
    }
}
