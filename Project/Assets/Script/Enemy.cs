using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeedX;
    public float MoveSpeedY;
    public float FlogJumpPowY;  // �J�G���̃W�����v��
    public float FlogJumpPowX;  // �J�G���̃W�����v��
    public float ReFJumpTime;  // �ăW�����v�ɂ�����b��
    public float KnockTime;  // �ăW�����v�ɂ�����b��
    public float JellyfishMaxHp;  //�N���QMaxHP
    public float SlimeMaxHp;  //�X���C��MaxHP
    public float WormMaxHp;  //��[��MaxHP
    public float FrogMaxHp;  //��[��MaxHP
    public float JellyfisHp;  // �N���QHp
    public float BatMaxHp;  // �N���QHp
    public float BatHp;  // �N���QHp
    public float DiffY;  // �N���QHp
    private Vector3 Dir;        // �v���C���[���������

    private string EnemyObj;     // Enemy�̖��O�擾�p

    public AudioSource Audio;

    public AudioClip DamageSE;

    public CollisionChaeck CollisionChaeck;    // ����
    public CollisionChaeck ChaseChaeck;    // ����
    public WallCollision WallChaeck;            // �ǔ���
    public EnemyCollson Damage;            // �ǔ���

    public GameObject DamageEffect;
    public GameObject DathEffect;

    private Vector2 EffectPos = Vector2.zero; 

    public bool isGround = false;  // �ڒn�t���O
    public bool isChase = false;  // �ǂ������t���O
    public bool isFlogJump = false;  // �J�G���̃W�����v�t���O
    public bool isEnter = false;  // ���n�����u�ԃt���O
    public bool isWall = false;  // �ǃt���O
    public bool isDamage = false;  // �_���[�W
    public bool isKnock = false;  // �m�b�N�o�b�N
    public bool isDathSE = false;  //��

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
