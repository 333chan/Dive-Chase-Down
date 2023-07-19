using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStandtrg : MonoBehaviour
{
    private string CatTag = "Cat";    // ínñ É^ÉO
    private bool isCat = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsCatStand()
    {
        return isCat;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == CatTag)
        {
            isCat = true;
        }
    }
}
