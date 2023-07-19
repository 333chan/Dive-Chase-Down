using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageTextPop : MonoBehaviour
{
    public Bgmtrg Bgmtrg;
    public Image Image;


    public float alpha;
    public float alphaFedoTime;
    public float PosY;
    public float DiffY;
    public float MoveTime;
    public float WaitTime;

    private bool isText = false;
    private bool isTextPop = false;
    private bool isTextMove = false;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;
        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, alpha);
        PosY = transform.position.y - DiffY;
    }

    // Update is called once per frame
    void Update()
    {
        isText = Bgmtrg.IsBgm();

        if(alpha>=1)
        {
            isTextPop = true;
            alpha = 1.0f;

            if(!isTextMove)
            {
                StartCoroutine(FeadOut());
            }

        }

        if (isText)
        {
            if(!isTextPop)
            {
                transform.DOMoveY(PosY, MoveTime);
                alpha += alphaFedoTime * Time.deltaTime;
                Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, alpha);
            }
 
        }

    }

    public IEnumerator FeadOut()
    {
        if(alpha<=0)
        {
            alpha = 0;
            isTextMove = true;
        }
        yield return new WaitForSeconds(WaitTime);
        PosY = transform.position.y;
        if (alpha >= 0)
        {
            transform.DOMoveY(PosY - DiffY/4, MoveTime);
            alpha -= alphaFedoTime * Time.deltaTime;
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, alpha);
        }



    }
}
