using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageflash : MonoBehaviour
{
    Texture2D scrTex;

    Image img;
    public Player2 PlayerFlg;    // プレイヤーのフラグ
    private bool isPDamege;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        isPDamege = PlayerFlg.isDamage;
        if (isPDamege)
        {

        }
        if(Input.GetMouseButtonDown(0))
        {

            img.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            img.color = Color.Lerp(img.color,Color.clear,Time.deltaTime*100);
        }
    }

    public void OnGUI()
    {

    }
}
