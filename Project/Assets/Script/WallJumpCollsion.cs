using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpCollsion : MonoBehaviour
{
    private string TileTag = "Ground";    // �n�ʃ^�O
    private bool isWallCollsion = false;    // �����蔻��

    private string BlockTag = "Block";    // �n�ʃ^�O

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
  //          Debug.Log("�ǃW�����̔���ɓ�����");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isWallStay = true;
    //        Debug.Log("�ǃW�����̔�����ɂ����");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isWallExit = true;
      //      Debug.Log("�ǃW�����̔��肩��o����");
        }
    }
}
