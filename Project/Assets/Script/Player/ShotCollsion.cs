using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollsion : MonoBehaviour
{
    private string GroundTag = "Ground";    // 弾タグ
    private string BlockTag = "Block";    // 弾タグ
    private string EnmeyTag = "Enemy";    // 敵タグ
    private bool isGroundedBullet = false;    // 着弾判定
    private bool isBlockBullet = false;    // ブロック判定
    private bool isEnemyBullet = false;    // 敵判定


    public bool IsGroundBullet()
    {
        return isGroundedBullet;
    }

    public bool IsBlockBullet()
    {
        return isBlockBullet;
    }

    public bool IsEnemyBullet()
    {
        return isEnemyBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GroundTag)
        {
            isGroundedBullet = true;
           // Debug.Log("着弾");
        }
        if(collision.tag == BlockTag)
        {

            Destroy(collision.gameObject);
            isBlockBullet = true;
        }

        if (collision.tag == EnmeyTag)
        {
            isEnemyBullet = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == GroundTag || collision.tag == BlockTag|| collision.tag == EnmeyTag)
        {
            isGroundedBullet = false;
            isBlockBullet = false;
            isEnemyBullet = false;
           // Debug.Log("着弾してない");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GroundTag || collision.tag == BlockTag || collision.tag == EnmeyTag)
        {
            isGroundedBullet = false;
            isBlockBullet = false;
            isEnemyBullet = false;
            Debug.Log("着弾してない");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
