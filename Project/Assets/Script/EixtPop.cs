using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EixtPop : MonoBehaviour
{
    public Text EixtText;
    public AudioClip EixtTextPopSE; 
    public AudioSource Audio;

    private bool isPlay = false; 

    // Start is called before the first frame update
    void Start()
    {
        isPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlay)
        {
            if (EixtText.color.a == 0)
            {
                StartCoroutine(ExitText());
            }
        }

    }

    public IEnumerator ExitText()
    {
        isPlay = true; 
        yield return new WaitForSeconds(2.0f);
        Audio.PlayOneShot(EixtTextPopSE);
        EixtText.color = new Color(EixtText.color.r, EixtText.color.g, EixtText.color.b, 1.0f);
    }
}
