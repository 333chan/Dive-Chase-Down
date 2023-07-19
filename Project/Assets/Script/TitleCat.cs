using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCat : MonoBehaviour
{

    private GameObject CatTrg;
    Titletrg TitleCatTrgScript;

    public GameObject JumpEffect;

    private Animator anime;
    public Rigidbody2D rb2d;

    public AudioSource Audio;
    public AudioClip CatJump;

    private bool isCat = false;
    private bool isCatActiv = false;
    private bool isCatJumpUp = false;
    private bool isCatJumpDown = false;

    public float CatJumpPow;
    public float diffy;
    private Vector2 EffectPos;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        CatTrg = GameObject.Find("TitleCatTrg");
        TitleCatTrgScript = CatTrg.GetComponent<Titletrg>();
    }

    // Update is called once per frame
    void Update()
    {
        isCat = TitleCatTrgScript.IsTite();
        EffectPos = Vector2.zero;
        EffectPos = new Vector2 (transform.position.x, transform.position.y- diffy);

        if (isCat)
        {
            if(!isCatActiv)
            {
                rb2d.AddForce(new Vector2(
                    (1 * CatJumpPow/2),
                    1 * CatJumpPow*1.2f),
                    ForceMode2D.Impulse);

                Instantiate(JumpEffect, EffectPos, Quaternion.identity);
                Audio.PlayOneShot(CatJump);
                isCatJumpUp = true;
                isCatActiv = true ;   
            }
        }

        if (rb2d.velocity.y < 0) 
        {
            isCatJumpUp = false;
            isCatJumpDown = true;
        }

        anime.SetBool("JumpUp", isCatJumpUp);
        anime.SetBool("JumpDown", isCatJumpDown);
    }
}
