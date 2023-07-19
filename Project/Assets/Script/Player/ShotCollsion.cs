using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollsion : MonoBehaviour
{
    private string GroundTag = "Ground";    // �e�^�O
    private string BlockTag = "Block";    // �e�^�O
    private string EnmeyTag = "Enemy";    // �G�^�O
    private bool isGroundedBullet = false;    // ���e����
    private bool isBlockBullet = false;    // �u���b�N����
    private bool isEnemyBullet = false;    // �G����


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
           // Debug.Log("���e");
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
           // Debug.Log("���e���ĂȂ�");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GroundTag || collision.tag == BlockTag || collision.tag == EnmeyTag)
        {
            isGroundedBullet = false;
            isBlockBullet = false;
            isEnemyBullet = false;
            Debug.Log("���e���ĂȂ�");
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
