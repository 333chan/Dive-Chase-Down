using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrg : MonoBehaviour
{
    private string PlayerTag = "Player";    // �n�ʃ^�O
    private bool isPCollsion = false;    // �v���C���[������������
    private bool isWCollsion = false;    // �ǂ̓����蔻��
    private bool isBlackBar = false;    //  ���т̏o������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsPlayer()
    {
        return isPCollsion;
    }

    public bool IsWall()
    {
        return isWCollsion;
    }

    public bool IsBlackBar()
    {
        return isBlackBar;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
           // Debug.Log("����ɓ�����");
            isPCollsion = true;
            isBlackBar = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isWCollsion = true;
           // Debug.Log("���肩��o����");
        }
    }

}
