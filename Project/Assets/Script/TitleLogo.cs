using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLogo : MonoBehaviour
{
    public Titletrg Ttrg;            //�󂯓n���p
    private bool isTtrg = false;     //�^�C�g���o���g���K�[
    private bool isParticle = true;  //�p�[�e�B�N���A�N�e�B�u�g���K�[

    private string TitleObj;         //�^�C�g�����o�̃I�u�W�F�N�g���擾�p

    public float alphaPow;           //Alpha�̉��Z��

    //�p�[�e�B�N���̍폜�ɂ����鎞��
    private float ParticledDethTime = 2.5f;

    //ParticleSystem�R���|�[�l���g�擾�p
    public ParticleSystem particle;

    //SpriteMask�R���|�[�l���g�擾�p
    private SpriteMask mask;

    //���ʉ�
    public AudioSource Audio;
    public AudioClip TitileLogoSE;

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g���擾
        TitleObj = this.gameObject.name;
        //SpriteMask�R���|�[�l���g���擾
        mask = GetComponent<SpriteMask>();      
    }

    // Update is called once per frame
    void Update()
    {
        //�^�C�g���̉��o���������
        isTtrg = Ttrg.IsTite();

        //�I�u�W�F�N�g���Ŕ��f
        switch (TitleObj)
        {
            case "Titlelogo":
                if (isTtrg)
                {
                    if (isParticle)
                    {
                        //�p�[�e�B�N���V�X�e���̃C���X�^���X����
                        ParticleSystem newParticle = Instantiate(particle);
                        // �����ꏊ���A�^�b�`���Ă���GameObject�̈ʒu��
                        newParticle.transform.position = this.transform.position;
                        //�p�[�e�B�N���̔���
                        newParticle.Play();
                        //���ʉ��̒���
                        Audio.pitch = 1;
                        Audio.volume = 1;
                        Audio.PlayOneShot(TitileLogoSE);

                        //�p�[�e�B�N���̍폜
                        Destroy(newParticle.gameObject, ParticledDethTime);  

                        //�p�[�e�B�N���t���O��false��
                        isParticle = false;
                    }
                }
                break;
            case "TitleMask":
                if (isTtrg)
                { 
                    if (mask.alphaCutoff <= 1)
                    {
                        //alphaCutoff��1�ɂȂ�܂ŉ��Z
                        mask.alphaCutoff += alphaPow*Time.deltaTime;
                    }
                }
                break;
            default:
                Debug.Log("�I�u�W�F�N�g���s��v");
                break;
        }



    }
}