using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyutoTrg : MonoBehaviour
{
    private string PlayerTag = "Player";    // �v���C���[�^�O
    private bool isPlayer = false;    // �v���C���[����

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
                       Debug.Log("�`���[�g���A���̔���ɓ�����");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isPlayer = false;
            //           Debug.Log("�`���[�g���A���̔���ɓ�����");
        }
    }
}
