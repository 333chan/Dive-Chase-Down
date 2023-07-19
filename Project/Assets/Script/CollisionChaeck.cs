using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChaeck: MonoBehaviour
{
    private string TileTag = "Ground";    // 地面タグ
    private bool isCollsion = false;    // 当たり判定

    private string BlockTag = "Block";    // 地面タグ

    private string PlayerTag = "Player";    // 地面タグ
    private bool isChase = false;    // 追いかけ判定

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
 //           Debug.Log("地面の判定に入った");
        }

        if (collision.tag == PlayerTag)
        {
            isChaseEnter = true;
            Debug.Log("追いかけの判定に入った");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isTileStay = true;
            isEnter = false;

            //          Debug.Log("地面の判定内にあるよ");
        }

        if (collision.tag == PlayerTag)
        {
            isChaseStay = true;
           Debug.Log("追いかけの判定内にある");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TileTag || collision.tag == BlockTag)
        {
            isTileExit = true;
            isEnter = false;
            isLanding = false;
            //          Debug.Log("地面の判定から出たよ");
        }
        if(collision.tag == PlayerTag)
        {
            isChaseExit = true;
        }
    }


}
