using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpTyutoPopUp : MonoBehaviour
{
    public OpPlayer Opplayer;
    private bool isGetUp;

    private SpriteRenderer sp;  // �X�v���C�g�����_���[�̊i�[�p
    public float alpha;     // �����x
    public float alphaFeadTime;  // ���Z����
    public float DiffY;     // Y����
    public float MoveTime;  // �ړ��ɂ����鎞��
    public float WaitTime;  // �ҋ@����

    private Vector2 Pos; // ���ݒn�i�[�p

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();    // �X�v���C�g�����_���[�̎擾
                                                // alpha = 0;  // ���������x
        Pos = transform.position;   // ���݂̈ʒu
    }

    // Update is called once per frame
    void Update()
    {
        isGetUp = Opplayer.IsGetUp();

        if(isGetUp)
        {
            StartCoroutine(TyutoPop());
        }
    }

    public IEnumerator TyutoPop()
    {

        yield return new WaitForSeconds(WaitTime);
        // �ړ�
        transform.DOMoveY(Pos.y + DiffY, MoveTime);


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
