using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrg : MonoBehaviour
{
    private string PlayerTag = "Player";    // �n�ʃ^�O
    private bool isStage = false;    // �����蔻��

    private string catTag = "Cat";    // �n�ʃ^�O

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
            Debug.Log("����ɓ�����");
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
           // Debug.Log("���肩��o����");
        }
    }

}
