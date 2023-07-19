using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision: MonoBehaviour
{
    private string TileTag = "Ground";    // 地面タグ
    private string BlokTag = "Block";    // 地面タグ
    private bool isWallCollsin = false;

    private bool isWallEnter, isWallStay, isWallExit;


    public bool IsWall()
    {
        if (isWallEnter || isWallStay)
        {
            isWallCollsin = true;
        }
        else if (isWallExit)
        {
            isWallCollsin = false;
        }
        isWallEnter = false;
        isWallStay = false;
        isWallExit = false;

        return isWallCollsin;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TileTag|| collision.tag == BlokTag)
        {
            isWallEnter = true;
 //           Debug.Log("地面の判定に入った");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlokTag)
        {
            isWallStay = true;
            //          Debug.Log("地面の判定内にあるよ");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlokTag)
        {
            isWallExit = true;
            //          Debug.Log("地面の判定から出たよ");
        }
    }


}
