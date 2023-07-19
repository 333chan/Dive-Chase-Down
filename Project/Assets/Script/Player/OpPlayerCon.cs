using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cinemachine;

public class OpPlayerCon : MonoBehaviour
{
    public float speed;                // 移動速度
    public float gravity;              // 重力
    public float jumpPow;              // ジャンプ力
    public float DoublejumpPow;        // ダブルジャンプ力
    public float WalljumpPow;          // 壁ジャンプ力
    public float BulletMaxNum;         // 発射可能な総弾数
    public float BulletNum;      // 発射回数
    public float ShotNum;      // 発射個数
    public float Hp;     // 体力
    public float MAXHp;  // 最大体力
    public float Damage;  // 敵から受けるダメージ
    public float Combo;  // コンボ
    public float footOnLength;
    public float MutekiTime;
    public float DushRecastTime;        // ダッシュの再使用時間
    public float ShotFireRate;
    public Vector2 VelLimit; // 重力上限

    public SpriteRenderer sp;
    public CollisionChaeck footCollision;    // 接地判定
    public WallJumpCollsion wallJump;        // 壁ジャンプ判定
    public AudioSource Audio;

    public OpPlayer opPlayer;

    public AudioClip Jumping;
    public AudioClip Landing;
    public AudioClip WallJumping;
    public AudioClip Dush;
    public AudioClip ShotSE;

    public GameObject JumpUpEfeact;
    public GameObject DubleJumpEfeact;
    public GameObject LandingEfeact;
    public GameObject WallJumpEfeact;
    public GameObject DushEfeact;
    public GameObject ShotBullet;
    public GameObject ReloadEffect;

    public Rigidbody2D rb2d;
    private BoxCollider2D BoxCol = null;

    private float InputX;       // 横入力
    public float SpeedX;

    public Vector2 DushPow;
    private float currentVelocity;

    Vector3 TarGetPos;

    private Animator anime;

    public float JumpEffectDiff;
    public float ShotDiff;
    Vector3 EffectPos;
    Vector2 DushEffectPos;
    Vector2 ShotPos;

    private bool isGround = false;  // 接地判定
    private bool isLanding = false;  // 着地判定
    private bool isWallJump = false;  // 壁ジャンプ判定
    private bool isWallJumpTime = false;  // 壁ジャンプ時間
    private bool isShot = false;  // 攻撃
    private bool isFootEnemy;       // 敵踏み
    private bool isKnock;    // ノックバック

    public bool isDamage = false;  // ダメージ
    public bool isReloaed = false;  // リロード

    private bool isJump = false;  // ジャンプ
    private bool isDoubleJump = false;  // ダブルジャンプ
    private bool isWJump = false;  // 壁ジャンプ
   private bool isDushAnim = false;    // ダッシュアニメーション
    private bool isDush = false;        // ダッシュ
    private bool isDushRecast = false;  // ダッシュのクールダウン
    private bool isShotAnim = false;    // ダッシュアニメーション

    private bool isGetUp = false; // 起きる

    private string EnemyTag = "Enemy";    // 敵タグ

    private bool isAudioPlay = false;    // オーディオの開始

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        BoxCol = GetComponent<BoxCollider2D>();
       // ImpulseSource = GetComponent<CinemachineImpulseSource>();
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
        isGetUp = opPlayer.IsGetUp();

        EffectPos = new Vector3(
            transform.position.x,
            transform.position.y - JumpEffectDiff,
            transform.position.z);

        ShotPos = new Vector2(
            transform.position.x,
            transform.position.y - ShotDiff);



        if (SceneManager.GetActiveScene().name == "TitleStage")
        {
        }

        if (Hp <= 0)
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
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

        if (SceneManager.GetActiveScene().name == "Home")
        {
            if (!isGetUp)
            {
                return;
            }
        }


        if (Input.GetButtonDown("Fire3")&& !Input.GetButtonDown("Jump"))
        {
            if(!Input.GetButtonDown("Jump"))
            {
                if (!isDushRecast)
                {
                    if(!isShotAnim)
                    {
                      //  isDush = true;

                      //  Dash();
                    }

                }
            }

        }

        //地面時
        if (isGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJump = true;
                Jump();
            }
        }


        if (rb2d.velocity.y > 0)
        {
            //ジャンプボタンを放した時
            if (Input.GetButtonUp("Jump"))
            {
                //ジャンプの上昇をやめる
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            }
        }

        // 地面にいない時
        if (!isGround)
        {
            
            if (rb2d.velocity.y > 0)
            {
                //上昇アニメーション
                isJump = true;
            }

            isAudioPlay = false;
        }

        if (rb2d.velocity.y < 0)
        {
            //下降アニメーション
            isJump = false;
        }

        // 地面に着地時
        if (isLanding)
        {
            if (!isAudioPlay)
            {
                //効果音の設定
                isAudioPlay = true;
                Audio.volume = 0.5f;
                Audio.PlayOneShot(Landing);

                // エフェクトの生成
                Instantiate(LandingEfeact, EffectPos, Quaternion.identity);
            }
        }

        // 画面の移動上限
        Vector3 screen_LeftLimit = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 screen_RightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

        transform.transform.position = new Vector3(
            Mathf.Clamp(
            transform.position.x,
            screen_LeftLimit.x + 0.1f,
            screen_RightLimit.x - 0.1f),
            transform.position.y,
            transform.position.z);
    }


    private void FixedUpdate()
    {
        // 移動キーの取得
        InputX = Input.GetAxisRaw("Horizontal");

        SpeedX = 0.0f;

        // シーンがHomeの時のみ
        if (SceneManager.GetActiveScene().name == "Home")
        {
            // ベットから起きるまで操作させないように
            if (!isGetUp)
            {
                return;
            }
        }

        if (InputX > 0)
        {
            //右移動
            transform.localScale = new Vector3(1, 1, 1);
            SpeedX = speed;
            anime.SetBool("Run", true);
        }
        else if (InputX < 0)
        {
            //左移動
            transform.localScale = new Vector3(-1, 1, 1);
            SpeedX = -speed;
            anime.SetBool("Run", true);
        }
        else
        {
            //停止時
            SpeedX = 0.0f;
            anime.SetBool("Run", false);
        }

        rb2d.velocity = new Vector2(SpeedX, rb2d.velocity.y);

        //アニメーションの設定
        anime.SetBool("Ground", isGround);
        anime.SetBool("Jump", isJump);

    }
    public void Run()
    {

    }
    public void Jump()
    {
        //効果音の設定
        Audio.pitch = 1;
        Audio.volume = 1;
        Audio.PlayOneShot(Jumping);

        //エフェクトの生成
        Instantiate(JumpUpEfeact, EffectPos, Quaternion.identity);

        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
    }

}



