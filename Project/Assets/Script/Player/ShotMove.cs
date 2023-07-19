using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    public float BulletSpeed;
    public float BulletDecelerateSpeed;
    private Rigidbody2D rb2d;
    private bool isBullet = false;
    private bool isBulletSpeedDown = false;

    public float DiffY;
    public float blockDiffY;
    private Vector2 EffectPos;
    private Vector2 BlockEffectPos;

    public ShotCollsion BulletCollision;    // ’…’e”»’è
    private bool isGuround = false;
    private bool isBlock = false;
    private bool isEnemy = false;

    public GameObject BulletEffect;
    public GameObject BlockEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGuround = BulletCollision.IsGroundBullet();
        isBlock = BulletCollision.IsBlockBullet();
        isEnemy = BulletCollision.IsEnemyBullet();
      //  Debug.Log(isGuround);

        EffectPos = new Vector2(
    transform.position.x,
    transform.position.y + DiffY);

        BlockEffectPos = new Vector2(
transform.position.x,
transform.position.y + blockDiffY);


        if (isGuround)
        {
            Instantiate(BulletEffect, EffectPos, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if(isBlock)
        {
            Instantiate(BlockEffect, BlockEffectPos, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (isEnemy)
        {
            Destroy(this.gameObject);
        }


        if (!isBullet)
        {
            if(!isBulletSpeedDown)
            {
                rb2d.AddForce(Vector2.down * BulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
              //  isBullet = true;
            }
            else
            {
                if (rb2d.velocity.y <= 0)
                {
                    rb2d.AddForce(Vector2.up * BulletDecelerateSpeed * Time.deltaTime, ForceMode2D.Impulse);
                }
                else if (rb2d.velocity.y >= 0)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                }
            }
 
        }
        
        //   transform.position = new Vector2(transform.position.x + BulletSpeed, transform.position.y);
    }

    public void BulletSpeedDown()
    {
        isBulletSpeedDown = true;
    }
}
