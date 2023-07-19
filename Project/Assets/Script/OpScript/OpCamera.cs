using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OpCamera : MonoBehaviour
{
    public float WaitTime;

    public CinemachineImpulseSource ImpulseSource;
    public AudioSource Audio;
    public AudioClip MeteoFall;
    public AudioClip Boom;

    public OpCatDestroy CatDestroy;     // îLçÌèúçœÇ›
    private bool isCatDestroy = false;

    private bool isMeteo=false;          // Ë¶êŒóéâ∫
    private bool isPlayBoomSE=false;    // îöî≠SEÇÃçƒê∂
    private bool isBoom=false;          // îöî≠

    public bool IsBoom()
    {
        return isBoom;
    }


    // Start is called before the first frame update
    void Start()
    {
        ImpulseSource = GetComponent<CinemachineImpulseSource>();
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isCatDestroy = CatDestroy.IsCatDestry();

        if(isCatDestroy)
        {

            if (!isMeteo)
            {
                StartCoroutine(Meteo());
            }

            if (!Audio.isPlaying&&isPlayBoomSE && isMeteo)
            {
                isPlayBoomSE = false;
                Audio.PlayOneShot(Boom);
                ImpulseSource.GenerateImpulse();
                isBoom = true;
            }
        }
    }

    private IEnumerator Meteo()
    {
        Debug.Log("î≠éÀÉ@ÅI");
        isMeteo = true;
        yield return new WaitForSeconds(WaitTime);
        isPlayBoomSE = true;
        Audio.PlayOneShot(MeteoFall);
    }

}
