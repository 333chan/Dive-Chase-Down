using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision: MonoBehaviour
{
    private string TileTag = "Ground";    // �n�ʃ^�O
    private string BlokTag = "Block";    // �n�ʃ^�O
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
 //           Debug.Log("�n�ʂ̔���ɓ�����");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlokTag)
        {
            isWallStay = true;
            //          Debug.Log("�n�ʂ̔�����ɂ����");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlokTag)
        {
            isWallExit = true;
            //          Debug.Log("�n�ʂ̔��肩��o����");
        }
    }


}
