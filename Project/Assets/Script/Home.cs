using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip DoorSE;

    public DoorTrg Dtrg;    // シーン遷移判定
    private bool isDtrg = false;  // シーンフラグ

    private bool isAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        isDtrg = Dtrg.IsPDoor();

        if(!Audio.isPlaying&&isAudio)
        {
            Destroy(this);
        }

        if(isDtrg)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(!isAudio)
                {
                    isAudio = true;
                    Audio.PlayOneShot(DoorSE);
                }

                isDtrg = false;
                SceneManager.LoadScene("TitleStage 1", LoadSceneMode.Single);

            }
        }


    }
}
