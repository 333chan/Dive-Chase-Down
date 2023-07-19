using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tyutopop : MonoBehaviour
{
    public TyutoTrg tyutoTrg;       // �`���[�g���A���\��
    private bool isTyutoPop = false;    // �`���[�g���A���\��

    private SpriteRenderer sp;  // �X�v���C�g�����_���[�̊i�[�p
    public float alpha;     // �����x
    public float alphaFeadTime;  // ���Z����
    public float DiffY;     // Y����
    public float MoveTime;  // �ړ��ɂ����鎞��
    public float WaitTime;  // �ҋ@����

    private bool isMoveUI = false;

    private Vector2 Pos; // ���ݒn�i�[�p

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();    // �X�v���C�g�����_���[�̎擾
        alpha = 0;  // ���������x
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, alpha);
        Pos = transform.position;   // ���݂̈ʒu
    }

    // Update is called once per frame
    void Update()
    {
        isTyutoPop = tyutoTrg.IsTyutoPop();

        if (isTyutoPop)
        {
            StartCoroutine(TyutoPopUI());
        }
    }

    public IEnumerator TyutoPopUI()
    {
        yield return new WaitForSeconds(WaitTime);
        // �ړ�
        transform.DOMoveY(Pos.y + DiffY, MoveTime);
        if (!isMoveUI)
        {
            isMoveUI = true;
        }

        // �����x�̉��Z
        if (alpha >= 1)
        {

            alpha = 1f;
        }
        else
        {
            alpha += alphaFeadTime * Time.deltaTime;
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, alpha);
        }
    }
}
