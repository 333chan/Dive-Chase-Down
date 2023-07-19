using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeedX;
    public float MoveSpeedY;
    public float FlogJumpPowY;  // カエルのジャンプ力
    public float FlogJumpPowX;  // カエルのジャンプ力
    public float ReFJumpTime;  // 再ジャンプにかかる秒数
    public float KnockTime;  // 再ジャンプにかかる秒数
    public float JellyfishMaxHp;  //クラゲMaxHP
    public float SlimeMaxHp;  //スライムMaxHP
    public float WormMaxHp;  //わーむMaxHP
    public float FrogMaxHp;  //わーむMaxHP
    public float JellyfisHp;  // クラゲHp
    public float BatMaxHp;  // クラゲHp
    public float BatHp;  // クラゲHp
    public float DiffY;  // クラゲHp
    private Vector3 Dir;        // プレイヤーがいる方向

    private string EnemyObj;     // Enemyの名前取得用

    public AudioSource Audio;

    public AudioClip DamageSE;

    public CollisionChaeck CollisionChaeck;    // 判定
    public CollisionChaeck ChaseChaeck;    // 判定
    public WallCollision WallChaeck;            // 壁判定
    public EnemyCollson Damage;            // 壁判定

    public GameObject DamageEffect;
    public GameObject DathEffect;

    private Vector2 EffectPos = Vector2.zero; 

    public bool isGround = false;  // 接地フラグ
    public bool isChase = false;  // 追いかけフラグ
    public bool isFlogJump = false;  // カエルのジャンプフラグ
    public bool isEnter = false;  // 着地した瞬間フラグ
    public bool isWall = false;  // 壁フラグ
    public bool isDamage = false;  // ダメージ
    public bool isKnock = false;  // ノックバック
    public bool isDathSE = false;  //死

    private Rigidbody2D rb2d;
    private Animator anime;

    private Transform targetTrans;

    public bool IsDathSE()
    {
        return isDathSE;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        EnemyObj = this.gameObject.name;
        targetTrans = GameObject.Find("Player").transform;

        JellyfishMaxHp = 3;
        JellyfisHp = JellyfishMaxHp;

        SlimeMaxHp = 3;
        WormMaxHp = 1;
        FrogMaxHp = 2;
        BatMaxHp = 3;

}

    // Update is called once per frame
    void Update()
    {
        isGround = CollisionChaeck.IsGroud();
        isChase = ChaseChaeck.IsChase();
        isEnter = CollisionChaeck.IsEnter();
        isDamage = Damage.IsEnemyBullet();

        isWall = WallChaeck.IsWall();

        

        float angleX = transform.localScale.x;
        Dir= (transform.position - targetTrans.position);
        Dir.Normalize();
        if(Dir.x>0)
        {
            Dir.x = 1;
        }
        if(Dir.x<0)
        {
            Dir.x = -1;
        }

        if (Dir.y > 0)
        {
            Dir.y = 1;
        }
        if (Dir.y < 0)
        {
            Dir.y = -1;
        }

        EffectPos = new Vector2(transform.position.x, transform.position.y + DiffY);

        switch (EnemyObj)
        {
            case "Slime":

                if (isDamage)
                {

                    Instantiate(DamageEffect, EffectPos, Quaternion.identity);
                    SlimeMaxHp--;
                    if (SlimeMaxHp < 1)
                    {
                        Instantiate(DathEffect, EffectPos, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Audio.PlayOneShot(DamageSE);
                    }
                }


                if (!isGround)
                {
                    angleX *= -1;
                }

                if (isWall)
                {
                    angleX *= -1;
                }

                transform.localScale = new Vector3(angleX, 1, 1);
                rb2d.velocity = new Vector2(-angleX * MoveSpeedX, rb2d.velocity.y);
                break;

            case "Flog":

                if (isDamage)
                {

                    Instantiate(DamageEffect, EffectPos, Quaternion.identity);
                    FrogMaxHp--;
                    if (FrogMaxHp < 1)
                    {
                        Instantiate(DathEffect, EffectPos, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Audio.PlayOneShot(DamageSE);
                    }
                }


                anime.SetBool("Ground", isGround);
                if (isGround)
                {
                    if(isChase)
                    {
                        if (isEnter)
                        {
                            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                        }
                        transform.localScale = new Vector3(-Dir.x, 1, 1);
                        if (!isFlogJump || rb2d.velocity.y < 0)
                        {
                            anime.SetBool("Jump", false);
                        }

                        if (isFlogJump)
                        {

                            return;
                        }
                        StartCoroutine(ReJump());
                    }

  

                }
                break;
                
            case "Jellyfish":

                if (isDamage)
                {
                   
                    rb2d.AddForce(Vector2.down * 9.5f, ForceMode2D.Impulse);
                    isKnock = true;
                    Instantiate(DamageEffect, EffectPos, Quaternion.identity);
                    JellyfisHp--;
                    if(JellyfisHp < 1)
                    {
                        Instantiate(DathEffect, EffectPos, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Audio.PlayOneShot(DamageSE);
                    }
                }

                if(isKnock)
                {
                    StartCoroutine(Knock());
                }


                if (isChase)
                {
                    rb2d.velocity = new Vector3(
                         MoveSpeedX * -Dir.x,
                         MoveSpeedY * -Dir.y,
                         transform.position.z);
                }
                break;

            case "Bat":


                if (isDamage)
                {

                    rb2d.AddForce(Vector2.down * 9.5f, ForceMode2D.Impulse);
                    isKnock = true;
                    Instantiate(DamageEffect, EffectPos, Quaternion.identity);
                    BatMaxHp--;
                    if (BatMaxHp < 1)
                    {
                        Instantiate(DathEffect, EffectPos, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Audio.PlayOneShot(DamageSE);
                    }
                }


                if (isChase)
                {
                    transform.localScale = new Vector3(Dir.x, 1, 1);

                    anime.SetBool("Fly", true);
                    rb2d.velocity = new Vector3(
                         MoveSpeedX * -Dir.x,
                         MoveSpeedY * -Dir.y,
                         transform.position.z);
                }
                break;

            case "worm":

                if (isDamage)
                {

                    Instantiate(DamageEffect, EffectPos, Quaternion.identity);
                    WormMaxHp--;
                    if (WormMaxHp < 1)
                    {
                        Instantiate(DathEffect, EffectPos, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Audio.PlayOneShot(DamageSE);
                    }
                }


                if (isChase)
                {
                    if (isWall)
                    {
                        angleX *= -1;
                    }

                    if (isGround)
                    {
                        anime.SetBool("Ground", isGround);
                        anime.SetBool("Fall", false);
                        transform.localScale = new Vector3(angleX, 1, 1);
                        rb2d.velocity = new Vector2(-angleX * MoveSpeedX, rb2d.velocity.y);
                    }
                    else
                    {
                        anime.SetBool("Fall", true);
                    }
                }


                break;
            default:
                Debug.Log(EnemyObj);
                break;
        }
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);




    }
    private IEnumerator ReJump()
    {
        isFlogJump = true;

        yield return new WaitForSeconds(ReFJumpTime);

        anime.SetBool("Jump", true);
        if (isFlogJump)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

            rb2d.AddForce(Vector2.up * FlogJumpPowY, ForceMode2D.Impulse);
            rb2d.AddForce(Vector2.right * FlogJumpPowX * -Dir.x, ForceMode2D.Impulse);

            isFlogJump = false;
      
        }

    }

    private IEnumerator Knock()
    {
        yield return new WaitForSeconds(KnockTime);
        if (isKnock)
        {
            isKnock = false;
            rb2d.velocity = new Vector2(0, 0);
        }

    }

}
