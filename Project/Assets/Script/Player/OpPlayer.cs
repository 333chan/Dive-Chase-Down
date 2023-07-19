using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpPlayer : MonoBehaviour
{

    public OpPlayerCon player;

    public float WaitTime;
    public float GetUpPow;

    public OpCamera opCamera;     // OpÉJÉÅÉâ
    private bool isBoom= false;

    public OpSkip Skip;
    private bool isSkip;

    private bool isGetUpJump= false;
    private bool isWakeUpJump= false;

    public Rigidbody2D rb2d;
    private Animator anime;


    public bool IsGetUp()
    {
        return isGetUpJump;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       isBoom = opCamera.IsBoom();
        isSkip = Skip.IsSkip();

        if (isSkip)
        {
            isGetUpJump = true;
        }

        if (!isGetUpJump)
        {
            if (isBoom)
            {
                isBoom = false;
                anime.SetBool("GetUp", true);

                StartCoroutine(GetUpJump());

            }
        }
        else
        {
            if(!isWakeUpJump)
            {
                isWakeUpJump = true;
                OpJump();
            }
        }


    }

    public IEnumerator GetUpJump()
    {

        yield return new WaitForSeconds(WaitTime);
        isGetUpJump = true;
    }

    public void OpJump()
    {
        anime.SetBool("Jump", true);
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * GetUpPow, ForceMode2D.Impulse);
    }
}
