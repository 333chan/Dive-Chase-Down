using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFlash : MonoBehaviour
{
    public Player2 PlayerDamage;
    private bool isDamage = false;
    private bool isFlash = false;

    public SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isDamage = PlayerDamage.IsPlayerDamage();
        if(isDamage)
        {
            if (!isFlash)
            {
                StartCoroutine(Flash());
            }
        }

        if(!isDamage)
        {
            isFlash = false;
        }
    }

    public IEnumerator Flash()
    {
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 255);
        yield return new WaitForSeconds(0.1f);
        isFlash = true;
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0);

    }
}
