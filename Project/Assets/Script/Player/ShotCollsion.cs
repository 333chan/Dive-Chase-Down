using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollsion : MonoBehaviour
{
    private string GroundTag = "Ground";    // íeÉ^ÉO
    private string BlockTag = "Block";    // íeÉ^ÉO
    private string EnmeyTag = "Enemy";    // ìGÉ^ÉO
    private bool isGroundedBullet = false;    // íÖíeîªíË
    private bool isBlockBullet = false;    // ÉuÉçÉbÉNîªíË
    private bool isEnemyBullet = false;    // ìGîªíË


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
           // Debug.Log("íÖíe");
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
           // Debug.Log("íÖíeÇµÇƒÇ»Ç¢");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GroundTag || collision.tag == BlockTag || collision.tag == EnmeyTag)
        {
            isGroundedBullet = false;
            isBlockBullet = false;
            isEnemyBullet = false;
            Debug.Log("íÖíeÇµÇƒÇ»Ç¢");
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
