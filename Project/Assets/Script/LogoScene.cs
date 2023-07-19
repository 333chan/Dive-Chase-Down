using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    [SerializeField] private float AlphaPow;    //Alpha�̉��Z��

    private float waitTime_ = 2.0f;  //�����ҋ@����

    private SpriteMask mask_;        //�R���|�[�l���g�擾�p

    private bool isLogo_ = false;    //logo�̕\���t���O
    private bool isMask_ = false;    //Mask�����t���O
    private bool isScene_ = false;   //Scene�J�ڃt���O


    // Start is called before the first frame update
    void Start()
    {
        //SpriteMask�R���|�[�l���g���擾
        mask_ = GetComponent<SpriteMask>();  
    }

    // Update is called once per frame
    void Update()
    {
        //�X�v���b�V���X�N���[���̕\�����I����Ă����
        if (SplashScreen.isFinished) 
        {
            if (!isLogo_)
            {
                isLogo_ = true;

                //�R���[�`�������J�n
                StartCoroutine(HometoScene());
            }
        }

        if(isMask_)
        {
            if (mask_.alphaCutoff <= 1)
            {
                //alphaCutoff��1�ɂȂ�܂ŉ��Z
                mask_.alphaCutoff += AlphaPow * Time.deltaTime;
            }
        }

        if(mask_.alphaCutoff == 1)
        {
            isMask_ = false;

            //�I�u�W�F�N�g�̕\�����I�t��
            gameObject.SetActive(false);

            isScene_ = true;
        }

        if(isScene_)
        {
            isScene_ = false;

            // HomeScene�ɑJ��
            SceneManager.LoadScene("Home", LoadSceneMode.Single);
        }

    }

    public IEnumerator HometoScene()
    {
        //2�b�ҋ@
        yield return new WaitForSeconds(waitTime_);
        isMask_ = true;
    }
}
