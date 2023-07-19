using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrg : MonoBehaviour
{
    private string PlayerTag = "Player";    // 地面タグ
    private bool isStage = false;    // 当たり判定

    private string catTag = "Cat";    // 地面タグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    public bool IsStage()
    {
        return isStage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isStage = true;
            Debug.Log("判定に入った");
        }
        if(collision.tag == catTag)
        {
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            //isPCollsion = false;
           // Debug.Log("判定から出たよ");
        }
    }

}
