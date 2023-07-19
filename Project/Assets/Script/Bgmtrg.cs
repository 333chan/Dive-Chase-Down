using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgmtrg : MonoBehaviour
{
    private string PlayerTag = "Player";    // ínñ É^ÉO
    private bool IsBGM = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsBgm()
    {
        return IsBGM;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            IsBGM = true;
        }
    }
}
