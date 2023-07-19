using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titletrg : MonoBehaviour
{

    private string PlayerTag = "Player";    // ínñ É^ÉO
    private bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTite()
    {
        return isPlayer;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isPlayer = true;
        }
    }

}
