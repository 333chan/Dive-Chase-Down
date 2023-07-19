using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClrearPop : MonoBehaviour
{
    public OpMask opMaskEnd;
    private bool isMaskEnd = false;
    private Text text;

    public float alpha;     // “§–¾“x
    public float alphaFeadTime;  // ‰ÁŽZŽžŠÔ



    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        isMaskEnd = opMaskEnd.IsMaskEnd();

        if(isMaskEnd)
        {
            // “§–¾“x‚Ì‰ÁŽZ
            if (alpha >= 1)
            {

            }
            else
            {
                alphaFeadTime += 1.5f* Time.deltaTime * 5.0f;
                alpha = Mathf.Sin(alphaFeadTime);
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            }
        }
    }
}
