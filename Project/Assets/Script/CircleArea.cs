using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleArea : MonoBehaviour
{
    public Player2 Player;

    private string PlayerTag = "Player";    // ínñ É^ÉO
    private bool isBGMStoping = false;

    private Animator anime;
    public AudioSource Audio;

    public AudioClip GlassSE;

    public GameObject GlassEffest;

    private Vector2 EffectPos = Vector2.zero;

    public float DiffY;

    public bool IsBgm()
    {
        return isBGMStoping;
    }


    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isBGMStoping = true;
            anime.enabled = false;
            EffectPos =  Player.transform.position;
            EffectPos.y = EffectPos.y + DiffY;
            Audio.pitch = 1;
            Audio.volume = 0.5f;
            Audio.PlayOneShot(GlassSE);
            Instantiate(GlassEffest, EffectPos, Quaternion.identity);
        }
    }
}
