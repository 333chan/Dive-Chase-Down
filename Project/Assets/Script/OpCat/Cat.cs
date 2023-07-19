using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cat : MonoBehaviour
{
    private Animator anime;
    public Rigidbody2D rb2d;
    public AudioSource Audio;

    public AudioClip nyn;

    public CatStandtrg Cattrg;
    private bool isCatStandtrg = false;  // óßÉgÉäÉKÅ[

    public float Speed;
    public float Speed2;
    public float IdolTime;
    public float StandTime;
    private bool isIdol = true;
    private bool isStand = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isCatStandtrg = Cattrg.IsCatStand();

        if (!isStand)
        {
            return;
        }

        if (isCatStandtrg)
        {
            anime.SetBool("Run", false);
            anime.SetBool("Stand", true);
            StartCoroutine(Stand());

        }

        if (!isIdol)
        {
            return;
        }
        else
        {
            StartCoroutine(Idol());
        }





    }
    private IEnumerator Idol()
    {
        isIdol = false;
        yield return new WaitForSeconds(IdolTime);
        anime.SetBool("Run", true);
        rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);

    }

    private IEnumerator Stand()
    {
        isStand = false;
        transform.localScale = new Vector3(1, 1, 1);
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        Audio.PlayOneShot(nyn);
        yield return new WaitForSeconds(StandTime);
        transform.localScale = new Vector3(-1, 1, 1);
        anime.SetBool("Stand", false);
        anime.SetBool("Run", true);
        rb2d.velocity = new Vector2(Speed2, rb2d.velocity.y);
    }



}
