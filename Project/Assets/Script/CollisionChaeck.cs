using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChaeck: MonoBehaviour
{
    private string TileTag = "Ground";    // �n�ʃ^�O
    private bool isCollsion = false;    // �����蔻��

    private string BlockTag = "Block";    // �n�ʃ^�O

    private string PlayerTag = "Player";    // �n�ʃ^�O
    private bool isChase = false;    // �ǂ���������

    private bool isLanding = false;
    private bool isBulletReload = false;

    private bool isTileEnter, isTileStay, isTileExit;
    private bool isChaseEnter, isChaseStay, isChaseExit;
    private bool isEnter;


    public bool IsEnter()
    {
        return isEnter;
    }
    public bool IsGroud()
    {
        if(isTileEnter || isTileStay)
        {
            isCollsion = true;
        }
        else if(isTileExit)
        {
            isCollsion = false;
        }
        isTileEnter = false;
        isTileStay = false;
        isTileExit = false;

        return isCollsion;
    }
    public bool IsLanding()
    {
        return isLanding;
    }

    public bool IsBulletReload()
    {
        return isBulletReload;
    }

    public bool IsChase()
    {
        if (isChaseEnter || isChaseStay || isChaseExit) 
        {
            isChase = true;
        }

        isChaseEnter = false;
        isChaseStay = false;
        isChaseExit = false;

        return isChase;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TileTag|| collision.tag == BlockTag)
        {
            isTileEnter = true;
            isEnter = true;
            isLanding = true;
            isBulletReload = true;
 //           Debug.Log("�n�ʂ̔���ɓ�����");
        }

        if (collision.tag == PlayerTag)
        {
            isChaseEnter = true;
            Debug.Log("�ǂ������̔���ɓ�����");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isTileStay = true;
            isEnter = false;

            //          Debug.Log("�n�ʂ̔�����ɂ����");
        }

        if (collision.tag == PlayerTag)
        {
            isChaseStay = true;
           Debug.Log("�ǂ������̔�����ɂ���");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isTileExit = true;
            isEnter = false;
            isLanding = false;
            //          Debug.Log("�n�ʂ̔��肩��o����");
        }
        if(collision.tag == PlayerTag)
        {
            isChaseExit = true;
        }
    }


}
