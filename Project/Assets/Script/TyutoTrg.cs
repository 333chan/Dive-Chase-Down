using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyutoTrg : MonoBehaviour
{
    private string PlayerTag = "Player";    // プレイヤータグ
    private bool isPlayer = false;    // プレイヤー判定

    public bool IsTyutoPop()
    {
        return isPlayer;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isPlayer = true;
                       Debug.Log("チュートリアルの判定に入った");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isPlayer = false;
            //           Debug.Log("チュートリアルの判定に入った");
        }
    }
}
