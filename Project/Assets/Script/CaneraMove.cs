using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CaneraMove : MonoBehaviour
{
    private CinemachineBrain cinemachineBrain;  //�R���|�[�l���g�擾�p

    public CameraTrg cameraTrg;              // �J�����g���K�[
    public StageTrg stageTrg;               // �X�e�[�W�g���K�[

    private bool isCamera = false;      // �J�����t���O
    private bool isStage = false;       // �X�e�[�W�ړ��t���O
    private bool isCameraMoved = false;  // �J�����ړ��ς݃t���O

    public float moveSpeedX;    // X�ړ���
    public float moveLenX;      // X�ړ�����

    public float moveSpeedY;    // Y�ړ�����
    public float moveLenY;      // Y�ړ�����

    [SerializeField] private float waitTime;      //�ҋ@����

    // Start is called before the first frame update
    void Start()
    {
        //cinemachineBrain�̃R���|�[�l���g�擾
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }

    public bool IsStageMove()
    {
        return isCameraMoved;
    }

    // Update is called once per frame
    void Update()
    {
        isCamera = cameraTrg.IsPlayer();   
        isStage = stageTrg.IsStage();

        //�J�������o���肪true
        if (isCamera)
        {
            //cinemachineBrain��off
            cinemachineBrain.enabled = false;

            //�J�����̈ړ����o
            this.transform.DOMove(
                new Vector3(
                    moveLenX, 
                    transform.position.y, 
                    transform.position.z), 
                moveSpeedX
                );
        }


        //�X�e�[�W�ړ����肪true
        if (isStage)
        {
            StartCoroutine(CameraMoveY());
        }
    }

    private IEnumerator CameraMoveY()
    {
        yield return new WaitForSeconds(waitTime);
        //�J�����̈ړ����o
        this.transform.DOMove(
            new Vector3(
                transform.position.x,
                -moveLenY,
                transform.position.z),
            moveSpeedY
            ).OnComplete(() =>
            {
                //�ړ�������
                isCameraMoved = true;
            });
    }
}
