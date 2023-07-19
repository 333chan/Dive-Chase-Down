using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearPlayer : MonoBehaviour
{
    private bool isMove = false;
    public AudioSource Audio;
    public AudioClip Cat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMove)
        {
            StartCoroutine(Move());
        }

    }
    public IEnumerator Move()
    {
        Audio.pitch = 1;
        Audio.volume = 0.5f;
        isMove = true;
        yield return new WaitForSeconds(1.0f);
        transform.DOMoveY(transform.position.y + 15.0f, 5.5f);
        Audio.PlayOneShot(Cat);


    }


}
