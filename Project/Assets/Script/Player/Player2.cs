using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cinemachine;

public class Player2 : MonoBehaviour
{
    public float speed;         // 移動速度
    public float gravity;        // 重力
    public float jumpPow;        // ジャンプ力
    public float jumpTime;         // ジャンプ時間
    public float DoublejumpPow;  // ダブルジャンプ力
    public float WalljumpPow;  // 壁ジャンプ力
    public float BulletMaxNum;  // 発射可能な総弾数
    public float BulletNum;      // 発射回数
    public float ShotNum;      // 発射個数
    public static float StartPlayerHp =10;      // 体力
    public float PlayerMaxHp;  // 最大体力
    public float PlayerCurrentHp;  // 最体力
    public float Damage;  // 敵から受けるダメージ
    public float Combo;  // コンボ
    public float footOnLength;
    public float MutekiTime;
    public float DushRecastTime;        // ダッシュの再使用時間
    public float ShotFireRate;  // 発射間隔
    public Vector2 VelLimit; // 重力上限

    public Text HpText;
    public Text ComboText;
    public Text BulletText;
    public SpriteRenderer sp;
    public CollisionChaeck footCollision;    // 接地判定
    public WallJumpCollsion wallJump;        // 壁ジャンプ判定
    public StageTrg Strg;                    // ステージ移動トリガ
    public StageToClear SToCtrg;             // ステージ移動トリガ
    public AudioSource Audio;

    public AudioClip RunSE;
    public AudioClip JumpingSE;
    public AudioClip LandingSE;
    public AudioClip WallJumpingSE;
    public AudioClip DushSE;
    public AudioClip ShotSE;
    public AudioClip EnemydathSE;
    public AudioClip DamageSE;
    public AudioClip PlayerDathSE;

    public GameObject RunStartEfeact;
    public GameObject JumpUpEfeact;
    public GameObject DubleJumpEfeact;
    public GameObject LandingEfeact;
    public GameObject WallJumpEfeact;
    public GameObject DushEfeact;
    public GameObject ShotBullet;
    public GameObject ShotEffect;
    public GameObject ReloadEffect;
    public GameObject DathEffect;
    public GameObject DamageEffect;

    public Rigidbody2D rb2d;
    public Slider Hpslider;
    public Slider HpMaxslider;
    public Slider Bulletslider;
    private BoxCollider2D BoxCol = null;
    public CinemachineImpulseSource ImpulseSource;

    private float InputX;       // 横入力
    private float InputY;       // ジャンプの入力
    public float SpeedX;
    private float SpeedY;
    private Vector2 vel = Vector2.zero;

    public Vector2 DushPow;
    private float currentVelocity;

    Vector3 TarGetPos;

    private Animator anime;

    public float RunStartEffectDiffY;
    public float JumpEffectDiff;
    public float ShotDiff;
    Vector3 EffectPos;
    Vector3 RunEffectPos;
    Vector2 DushEffectPos;
    Vector2 ShotPos;

    private bool isGround = false;  // 接地判定
    private bool isLanding = false;  // 着地判定
    private bool isWallJump = false;  // 壁ジャンプ判定
    private bool isWallJumpTime = false;  // 壁ジャンプ時間
    private bool isShot = false;  // 攻撃
    private bool isFootEnemy;       // 敵踏み
    private bool isKnock;    // ノックバック
    private bool isStgr;    // ステージ

    public bool isDamage = false;  // ダメージ
    public bool isReloaed = false;  // リロード

    private bool isControlBan = false;  // 操作不能
    private bool isRunEffect = false;  // 歩きアニメーション
    private bool isJump = false;  // ジャンプ
    private bool isDoubleJump = false;  // ダブルジャンプ
    private bool isWJump = false;  // 壁ジャンプ
    private bool isDushAnim = false;    // ダッシュアニメーション
    private bool isDush = false;        // ダッシュ
    private bool isDushRecast = false;  // ダッシュのクールダウン
    private bool isShotAnim = false;    // ダッシュアニメーション
    private bool isPlayerDamage = false;

    private static float HpValueNum = 1.0f;

    private string EnemyTag = "Enemy";    // 敵タグ
    private string SChangeCircleAreaTag = "SChangeCircleArea";    // ステージクリアのサークルエリアタグ

    private bool isAudioPlay = false;    // オーディオの開始

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        BoxCol = GetComponent<BoxCollider2D>();
        // ImpulseSource = GetComponent<CinemachineImpulseSource>();

        Hpslider.value = HpValueNum;
        //HpMaxslider.value = 0;
        PlayerCurrentHp = StartPlayerHp;

        if (PlayerCurrentHp <= 0)
        {
            StartPlayerHp = 10;
            PlayerCurrentHp = 10;
        }

        if (Hpslider.value <= 0)
        {
            Hpslider.value = 1;
        }

        if (SceneManager.GetActiveScene().name == "TitleStage 1")
        {
            Hpslider.value = 1;
            StartPlayerHp = 10;
            PlayerCurrentHp = 10;
        }

        if (StartPlayerHp == 10 && PlayerCurrentHp == 10)
        {
            Hpslider.value = 1;
        }
    }

    public bool IsReload()
    {
        return isReloaed;

    }

    // Update is called once per frame
    void Update()
    {
        isGround = footCollision.IsGroud();
        isWallJump = wallJump.IsWallJump();
        isLanding = footCollision.IsLanding();
        isStgr = Strg.IsStage();

        EffectPos = new Vector3(
            transform.position.x,
            transform.position.y - JumpEffectDiff,
            transform.position.z);

        ShotPos = new Vector2(
            transform.position.x,
            transform.position.y - ShotDiff);


        if (HpMaxslider.value >=1)
        {
            HpMaxslider.value = 0;
            PlayerCurrentHp = StartPlayerHp;
            StartPlayerHp = StartPlayerHp + 1;
        }

        if (SceneManager.GetActiveScene().name == "TitleStage")
        {

        }
        else
        {
            if (PlayerCurrentHp < 0)
            {
                PlayerCurrentHp = 0;
            }

            HpText.text =PlayerCurrentHp.ToString() + "/"+ PlayerMaxHp;

            if (isFootEnemy)
            {
                Combo += 1;
            }

            if (isGround)
            {
                Combo = 0;
            }


            ComboText.text = Combo.ToString();

            if (Combo>0)
            {
                if(!isControlBan)
                {
                    ComboText.enabled = true;
                }

            }
            else
            {
                ComboText.enabled = false;
            }


            if (isGround)
            {
                Reload();
            }

            BulletText.text = BulletNum.ToString();
        }

        if (PlayerCurrentHp <= 0)
        {
           // SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
        }

        if (isStgr)
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }

        if (VelLimit.y > rb2d.velocity.y)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, VelLimit.y);
        }

        if (isDamage)
        {

            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1.0f, 1.0f, 1.0f, level);

        }

        if (SceneManager.GetActiveScene().name == "StageClear" || isControlBan)
        {
            return;
        }
        else
        {

            if (Input.GetButtonDown("Fire3") && !Input.GetButtonDown("Jump"))
            {
                if (!Input.GetButtonDown("Jump"))
                {
                    if (!isDushRecast)
                    {
                        if (!isShotAnim)
                        {
                            isDush = true;

                            Dash();
                        }

                    }
                }

            }

            if (isGround)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    isJump = true;
                    Jump();
                }


                if (BulletNum < BulletMaxNum)
                {
                    BulletNum = BulletMaxNum;
                }



                isDoubleJump = false;
                isWJump = false;
                isShotAnim = false;
                // Debug.Log("地面");// 接地判定
            }


            if (rb2d.velocity.y > 0)
            {
                if (Input.GetButtonUp("Jump"))
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                }
            }

            if (!isGround)
            {

                if (!isWallJump)    // 壁と接触しているか
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (!isDoubleJump)
                        {
                            DoubleJump();
                        }
                    }
                }
                else if (isWJump)    // 壁ジャンプは使用したか？
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (!isDoubleJump)
                        {
                            DoubleJump();
                        }
                    }
                }
                else
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        if (!isWJump)
                        {
                            WallJump();
                        }
                        //if (!isDoubleJump)
                        //{
                            DoubleJump();
                        //}
                    }
                }

                if (rb2d.velocity.y > 0)
                {

                    isJump = true;
                }

                if (Input.GetButton("Fire2"))
                {
                    if (!Input.GetButtonDown("Fire3"))
                    {
                        if (BulletNum > 0)
                        {
                            Shot();
                        }

                    }

                }
                else
                {
                    isShotAnim = false;
                }

                isAudioPlay = false;
            }

            if (rb2d.velocity.y < 0)
            {
                isJump = false;
            }

            if (isFootEnemy)
            {
                Instantiate(DathEffect, transform.position, Quaternion.identity);
                Audio.PlayOneShot(EnemydathSE);
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(transform.up * 15.0f, ForceMode2D.Impulse);
                //  Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                isFootEnemy = false;
                isDoubleJump = false;
                isWallJump = false;
                isDushRecast = false;

            }

            if (isLanding)
            {
                if (!isAudioPlay)
                {
                    jumpTime = 0;
                    isAudioPlay = true;
                    Audio.volume = 0.5f;
                    Audio.PlayOneShot(LandingSE);
                    Instantiate(LandingEfeact, EffectPos, Quaternion.identity);
                }
            }
        }

        Vector3 screen_LeftLimit = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 screen_RightLimit = Camera.main.ScreenToWorldPoint(new Vector3
            (Screen.width,
            Screen.height,
            0));

        //if (transform.position.x < screen_LeftLimit.x && rb2d.velocity.x < 0) 
        //{
        //    Debug.Log("端");
        //    speed = 0;
        //}
        transform.transform.position = new Vector3(Mathf.Clamp
            (transform.position.x,
            screen_LeftLimit.x + 0.1f,
            screen_RightLimit.x - 0.1f),
            transform.position.y,
            transform.position.z);
    }


    private void FixedUpdate()
    {
        
        InputX = Input.GetAxisRaw("Horizontal");
        //InputY = Input.GetAxis("Jump");

        SpeedX = 0.0f;
        SpeedY = -gravity;      // 重力

        if (SceneManager.GetActiveScene().name == "StageClear"|| isControlBan)
        {
            return;
        }
        else
        {
            // Debug.Log(InputX);
            if (!isDush)
            {
                if (InputX > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    SpeedX = speed;
                    anime.SetBool("Run", true);
                    RunEffect();


                }
                else if (InputX < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    SpeedX = -speed;
                    anime.SetBool("Run", true);
                    RunEffect();
                }
                else
                {
                    SpeedX = 0.0f;
                    isRunEffect = false;
                    anime.SetBool("Run", false);
                }
                if (!isWallJumpTime)
                {
                    rb2d.velocity = new Vector2(SpeedX, rb2d.velocity.y);
                }
                else
                {
                    if (InputX == 1)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x + InputX, rb2d.velocity.y);
                    }
                    if (InputX == -1)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x + InputX, rb2d.velocity.y);
                    }
                }

            }
        }

        
        anime.SetBool("Ground", isGround);
        anime.SetBool("Jump", isJump);
        anime.SetBool("Dush", isDushAnim);
        anime.SetBool("Shot", isShotAnim);

    }

    public void Run()
    {
        if(!Input.GetButtonDown("Jump"))
        {
            Audio.pitch = 1.85f;
            Audio.volume = 0.1f;
            Audio.PlayOneShot(RunSE);
        }
        
    }

    public void RunEffect()
    {
        RunEffectPos = EffectPos;
        RunEffectPos.y=RunEffectPos.y + RunStartEffectDiffY;
        if (isGround) 
        {
            if (!isRunEffect)
            {
                if (transform.localScale.x < 1.0f)
                {
                    isRunEffect = true;
                    Instantiate(RunStartEfeact, RunEffectPos, Quaternion.Euler(0, 180, 0));
                }
                else
                {
                    isRunEffect = true;
                    Instantiate(RunStartEfeact, RunEffectPos, Quaternion.identity);
                }

            }
        }


    }



    public void Jump()
    {

        rb2d.gravityScale = 4.5f;
        Audio.pitch = 1;
        Audio.volume = 1;
        Audio.PlayOneShot(JumpingSE);
        Instantiate(JumpUpEfeact, EffectPos, Quaternion.identity);
        rb2d.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);

    }

    public void DoubleJump()
    {
        rb2d.gravityScale = 4.5f;
        isDoubleJump = true;
        Audio.pitch = 1.5f;
        Audio.volume = 1;
        Audio.PlayOneShot(JumpingSE);
        Instantiate(DubleJumpEfeact, EffectPos, Quaternion.identity);
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * DoublejumpPow, ForceMode2D.Impulse);

    }

    public void WallJump()
    {
        isWJump = true;
        Audio.pitch = 1.8f;
        Audio.volume = 0.5f;
        Audio.PlayOneShot(WallJumpingSE);
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        if (transform.localScale.x<1.0f)
        {
            Instantiate(WallJumpEfeact, EffectPos, Quaternion.Euler(0, 0, 180));
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Instantiate(WallJumpEfeact, EffectPos, Quaternion.identity);
            transform.localScale = new Vector3(-1, 1, 1);
        }

          rb2d.AddForce(new Vector2((-1 * WalljumpPow/2)*-transform.localScale.x, 1 * WalljumpPow) , 
              ForceMode2D.Impulse);
           StartCoroutine(WallJumpTime());

    }

    public void Shot()
    {
        if(isShot)
        {
            return;
        }

        if(!isShot)
        {
            //画面振動の信号送信
            //CinemachineImpulseSource ImpulseSource;
            //ImpulseSource.GenerateImpulse();

            if (BulletNum <= 18&& BulletNum > 8)
            {
                Audio.pitch = 1.5f;
            }
            else if (BulletNum <= 8)
            {
                Audio.pitch = 2.0f;
            }
            else
            {
                Audio.pitch = 1.0f;
            }
            Audio.volume = 0.7f;
            Audio.PlayOneShot(ShotSE);
            BulletNum = BulletNum - ShotNum;
            Bulletslider.value = BulletNum / BulletMaxNum;
            isShotAnim = true;
            Instantiate(ShotEffect, ShotPos,Quaternion.identity);
            Instantiate(ShotBullet, ShotPos, Quaternion.identity);
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * 1.75f, ForceMode2D.Impulse);
            StartCoroutine(ShotRate());

        }
        
    }
    public void Dash()
    {
        if (isDush)
        {
            if (rb2d.gravityScale >= 0)
            {
                rb2d.gravityScale = 0;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            }
            isDushAnim = true;
            DushEffectPos = new Vector2(
                transform.position.x,
                transform.position.y + 0.1f);

            if (transform.localScale.x < 1.0f)
            {
                Instantiate(DushEfeact, DushEffectPos, Quaternion.Euler(0, 180, 0));
            }
            else
            {

                Instantiate(DushEfeact, DushEffectPos, Quaternion.identity);
            }

            rb2d.AddForce((Vector2.right * transform.localScale) * DushPow.x, ForceMode2D.Impulse);
            
        }
        
    }

    public void DashEnd()
    {
        Audio.pitch = 1;
        Audio.volume = 0.5f;
        Audio.PlayOneShot(DushSE);
        if (rb2d.gravityScale <= 0) 
        {
            rb2d.gravityScale = 4.5f;
        }

        isDush = false;
        isDushAnim = false;
        StartCoroutine(DushRecast());

    }

    public void Reload()
    {
        if (BulletMaxNum > BulletNum)
        {
            Instantiate(ReloadEffect, transform.position, Quaternion.identity);
            isReloaed = true;
            BulletNum = BulletMaxNum;
        }
        else
        {
            isReloaed = false;
        }

        Bulletslider.value = 1;
    }

    public bool IsPlayerDamage()
    {
        return isPlayerDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!isControlBan)
        {
            if (collision.collider.tag == EnemyTag)
            {
                float stepOnheight = BoxCol.size.y * (footOnLength / 150f);

                float judgePosY = transform.position.y - (BoxCol.size.y / 2f) + stepOnheight;

                foreach (ContactPoint2D p in collision.contacts)
                {
                    if (p.point.y < judgePosY)
                    {
                        // ジャンプ
                        isFootEnemy = true;
                        //ImpulseSource.GenerateImpulse();
                        Destroy(collision.gameObject);
                        Reload();
                    }
                    else
                    {
                        // ダメージ
                        if (isDamage)
                        {
                            return;
                        }

                        isDamage = true;

                        StartCoroutine(OnDamage());
                        StartCoroutine(DamageSlowtime());
                        isPlayerDamage = true;
                        break;
                    }
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == SChangeCircleAreaTag)
        {
            isControlBan = true;
        }
    }

    public IEnumerator DamageSlowtime()
    {
        Instantiate(DamageEffect, transform.position, Quaternion.identity);
        //ImpulseSource.GenerateImpulseAt(transform.position, rb2d.velocity*0.5f);


        if (PlayerCurrentHp <=0)
        {

            Combo = 0;
            isControlBan = true;
            Audio.pitch = 1.5f;
            Audio.volume = 1.5f;
            Audio.PlayOneShot(PlayerDathSE);
            anime.SetBool("Dath", true);
            rb2d.AddForce(new Vector2((-1 * WalljumpPow / 2) * transform.localScale.x, 1 * WalljumpPow),
    ForceMode2D.Impulse);
            Time.timeScale = 0.5f;
            yield return new WaitForSeconds(1.0f);
            //        Time.timeScale = 0.0f;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
        }
        else
        {
            Time.timeScale = 0.5f;
            yield return new WaitForSeconds(0.2f);
            Time.timeScale = 1.0f;
        }
    }

    public IEnumerator OnDamage()
    {
        Audio.pitch = 1.5f;
        Audio.volume = 0.8f;
        Audio.PlayOneShot(DamageSE);

        var knockPosX = (transform.position.x + 0.2f);

        if (rb2d.velocity.x < 0 || rb2d.velocity.x > 0)
        {
            if (transform.localScale.x >= 0)
            {
                 Debug.Log("ノック");
                //rb2d.DOMove(new Vector2(transform.position.x - 0.8f, transform.position.y + 0.8f), 0.3f);
                //if (Input.anyKey)
                //{
                //    DOTween.KillAll();
                //}
                
               
            }
            else
            {
                //   rb2d.AddForce(transform.right * 40000.0f);
            }
        }

        StartPlayerHp = StartPlayerHp - Damage;
        PlayerCurrentHp = StartPlayerHp;
        HpValueNum = PlayerCurrentHp / PlayerMaxHp;
        Hpslider.value = HpValueNum;
        yield return new WaitForSeconds(MutekiTime);

        isDamage = false;
        isPlayerDamage = false;

        sp.color = new Color(1f, 1f, 1f, 1f);
    }

    public IEnumerator ShotRate()
    {
        isShot = true;
        yield return new WaitForSeconds(ShotFireRate);
        isShot = false;
    }

    public IEnumerator WallJumpTime()
    {
        isWallJumpTime = true;
        yield return new WaitForSeconds(0.3f);
        isWallJumpTime = false;
    }

    public IEnumerator DushRecast()
    {
        isDushRecast = true;
        yield return new WaitForSeconds(DushRecastTime);
        isDushRecast = false;

    }
}



